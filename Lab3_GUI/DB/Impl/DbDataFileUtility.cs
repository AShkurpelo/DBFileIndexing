using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab3.DB.Impl
{
    class DbDataFileUtility
    {
        public static KeyValuePair<int, object>[] ReadOverloadZone(IDbConnection dbConnection)
        {
            var records = new List<KeyValuePair<int, object>>();
            var descriptor = dbConnection.GetDescriptor();
            var overloadRecordSize = descriptor.RecordSize + descriptor.LinkSize;
            var formatter = new BinaryFormatter();
            var fs = dbConnection.GetDataFileStream();
            fs.Position = descriptor.DataBlocksCount * descriptor.BlockSize;
            using (var stream = new MemoryStream())
            {
                var buffer = new byte[descriptor.OverloadSize];
                fs.Read(buffer, 0, buffer.Length);
                stream.Write(buffer, 0, buffer.Length);
                long offset = 0;
                while (offset < descriptor.OverloadSize)
                {
                    stream.Position = offset;
                    try
                    {
                        records.Add((KeyValuePair<int, object>)formatter.Deserialize(stream));
                    }
                    catch (Exception e)
                    {
                        records.Add(new KeyValuePair<int, object>(-1, null));
                    }
                    offset += overloadRecordSize;
                }
            }

            return records.ToArray();
        }

        public static KeyValuePair<int, object>[] GetBlockRecords(int blockNumber, IDbConnection dbConnection)
        {
            var records = new List<KeyValuePair<int, object>>();
            var descriptor = dbConnection.GetDescriptor();
            var formatter = new BinaryFormatter();
            var fs = dbConnection.GetDataFileStream();
            using (var stream = new MemoryStream())
            {
                fs.Position = descriptor.BlockSize * blockNumber;
                var buffer = new byte[descriptor.BlockSize];
                fs.Read(buffer, 0, buffer.Length);
                stream.Write(buffer, 0, buffer.Length);
                stream.Position = 0;
                while (stream.CanRead)
                {
                    try
                    {
                        records.Add((KeyValuePair<int, object>)formatter.Deserialize(stream));
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
                stream.Seek(-descriptor.LinkSize, SeekOrigin.End);
                var overloadPosition = (int)formatter.Deserialize(stream);
                while (overloadPosition != -1)
                {
                    fs.Position = descriptor.DataBlocksCount * descriptor.BlockSize + overloadPosition;
                    records.Add((KeyValuePair<int, object>)formatter.Deserialize(fs));
                    overloadPosition = (int)formatter.Deserialize(fs);
                }
            }
            return records.ToArray();
        }

        private static void WriteBlockRecords(KeyValuePair<int, object>[] records, int blockNumber, IDbConnection dbConnection)
        {
            var descriptor = dbConnection.GetDescriptor();
            var maxBlockRecordsCount = descriptor.BlockSize / descriptor.RecordSize;
            var overload = maxBlockRecordsCount < records.Length;
            var formatter = new BinaryFormatter();
            var fs = dbConnection.GetDataFileStream();
            fs.Position = descriptor.BlockSize * blockNumber;
            if (overload)
            {
                for (int i = 0; i < maxBlockRecordsCount; ++i)
                {
                    formatter.Serialize(fs, records[i]);
                }
                fs.Position = (blockNumber + 1) * descriptor.BlockSize - descriptor.LinkSize;
                var position = (int)formatter.Deserialize(fs);
                bool increaseOverloadSize = false;
                if (position == -1)
                {
                    position = descriptor.OverloadSize;
                    fs.Position = (blockNumber + 1) * descriptor.BlockSize - descriptor.LinkSize;
                    formatter.Serialize(fs, position);
                    increaseOverloadSize = true;
                }
                fs.Position = descriptor.DataBlocksCount * descriptor.BlockSize + position;
                var linkedRecordSize = descriptor.RecordSize + descriptor.LinkSize;
                for (var i = maxBlockRecordsCount; i < records.Length; ++i)
                {
                    formatter.Serialize(fs, records[i]);

                    if (increaseOverloadSize)
                    {
                        descriptor.OverloadSize += (int)linkedRecordSize;
                        position = descriptor.OverloadSize;
                    }
                    else
                    {
                        var fsPosition = fs.Position;
                        try
                        {
                            position = (int)formatter.Deserialize(fs);
                            if (position == -1)
                                throw new Exception();
                        }
                        catch (Exception ex)
                        {
                            position = descriptor.OverloadSize;
                            increaseOverloadSize = true;
                        }
                        fs.Position = fsPosition;
                    }

                    formatter.Serialize(fs, i == records.Length - 1 ? -1 : position);
                }
            }
            else
            {
                for (int i = 0; i < records.Length; ++i)
                {
                    formatter.Serialize(fs, records[i]);
                }
                fs.Position = (blockNumber + 1) * descriptor.BlockSize - descriptor.LinkSize;
                formatter.Serialize(fs, -1);
            }
        }

        private static void ClearBlock(int blockNumber, IDbConnection dbConnection)
        {
            var descriptor = dbConnection.GetDescriptor();
            var recordsZoneSize = (descriptor.BlockSize / descriptor.RecordSize) * descriptor.RecordSize;
            var fs = dbConnection.GetDataFileStream();
            fs.Position = descriptor.BlockSize * blockNumber;
            fs.Write(new byte[recordsZoneSize], 0, (int) recordsZoneSize);
            fs.Flush();
        }

        private static KeyValuePair<int, object>[] ReplaceOrAdd(KeyValuePair<int, object>[] records, KeyValuePair<int, object> newRecord)
        {
            List<KeyValuePair<int, object>> list;
            var record = records[0];
            if (record.Key == newRecord.Key)
            {
                records[0] = newRecord;
                return records;
            }
            if (record.Key > newRecord.Key)
            {
                list = records.ToList();
                list.Insert(0, newRecord);
                return list.ToArray();
            }
            long n = records.Length;
            long k = (long)Math.Log(n, 2) - 1;
            long i = (long)Math.Pow(2, k);

            record = records[i];
            if (newRecord.Key > record.Key)
            {
                int l = (int)Math.Log(n - i + 1, 2);
                i = n + 1 - (int)Math.Pow(2, l);
                k = l;
                record = records[i];
            }
            int offset = (int)Math.Pow(2, k - 1);
            while (offset != 0)
            {
                if (record.Key == newRecord.Key)
                {
                    records[i] = newRecord;
                    return records;
                }
                if (record.Key > newRecord.Key)
                    i -= offset;
                else
                    i += offset;
                if (i == records.Length)
                    i--;
                offset /= 2;
                record = records[i];
            }
            if (record.Key == newRecord.Key)
            {
                records[i] = newRecord;
                return records;
            }
            list = records.ToList();
            var index = records[i].Key < newRecord.Key ? i + 1 : i;
            list.Insert((int)index, newRecord);
            return list.ToArray();
        }

        public static long GetObjectSize(Object record)
        {
            using (var s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, record);
                return s.Length;
            }
        }

        public static IndexRecord[] RewriteWithIndexRebuild(
            SortedDictionary<int, object> data, IDbConnection dbConnection)
        {
            var descriptor = dbConnection.GetDescriptor();
            descriptor.RecordSize = GetObjectSize(data.First());
            var maxBlockRecordsCount = descriptor.BlockSize / descriptor.RecordSize;
            var blockRecordsCount = (int)(maxBlockRecordsCount * (descriptor.FillFactor / 100.0));
            var blocksCount = data.Count / blockRecordsCount;
            if (data.Count % blockRecordsCount > 0)
                ++blocksCount;
            var indexes = new IndexRecord[blocksCount];
            var formatter = new BinaryFormatter();
            var fs = dbConnection.GetDataFileStream();
            fs.SetLength(0);
            fs.Flush();
            using (var iter = data.GetEnumerator())
            {
                iter.MoveNext();
                for (int block = 0; block < blocksCount; ++block)
                {
                    fs.Position = block * descriptor.BlockSize;
                    indexes[block] = new IndexRecord { Key = iter.Current.Key, Block = block };
                    for (int i = 0; i < blockRecordsCount; ++i)
                    {
                        formatter.Serialize(fs, iter.Current);
                        if (!iter.MoveNext())
                            break;
                    }
                    fs.Position = (block + 1) * descriptor.BlockSize - descriptor.LinkSize;
                    formatter.Serialize(fs, -1);
                }
            }
            descriptor.DataBlocksCount = blocksCount;
            descriptor.IndexRecordSize = GetObjectSize(indexes[0]);
            descriptor.OverloadSize = 0;
            return indexes;
        }

        public static KeyValuePair<int, object>? FindRecord(int key, int blockNumber, IDbConnection dbConnection)
        {
            var records = GetBlockRecords(blockNumber, dbConnection);
            var record = records[0];
            if (record.Key == key)
                return record;
            long n = records.Length;
            long k = (long)Math.Log(n, 2) - 1;
            long i = (long)Math.Pow(2, k);

            record = records[i];
            if (key > record.Key)
            {
                int l = (int)Math.Log(n - i + 1, 2);
                i = n + 1 - (int)Math.Pow(2, l);
                k = l;
                record = records[i];
            }
            int offset = (int)Math.Pow(2, k - 1);
            while (offset != 0)
            {
                if (record.Key == key)
                    return record;
                if (record.Key > key)
                    i -= offset;
                else
                    i += offset;
                if (i == records.Length)
                    i--;
                offset /= 2;
                record = records[i];
            }
            if (record.Key == key)
                return record;
            return null;
        }

        public static KeyValuePair<int, object>? FindRecordWithStatistic(int key, int blockNumber,
            IDbConnection dbConnection, ref int comparasions)
        {
            var records = GetBlockRecords(blockNumber, dbConnection);
            var record = records[0];
            comparasions++;
            if (record.Key == key)
                return record;
            long n = records.Length;
            long k = (long)Math.Log(n, 2) - 1;
            long i = (long)Math.Pow(2, k);

            record = records[i];
            comparasions++;
            if (key > record.Key)
            {
                int l = (int)Math.Log(n - i + 1, 2);
                i = n + 1 - (int)Math.Pow(2, l);
                k = l;
                record = records[i];
            }
            int offset = (int)Math.Pow(2, k - 1);
            while (offset != 0)
            {
                comparasions++;
                if (record.Key == key)
                    return record;
                comparasions++;
                if (record.Key > key)
                    i -= offset;
                else
                    i += offset;
                if (i == records.Length)
                    i--;
                offset /= 2;
                record = records[i];
            }
            comparasions++;
            if (record.Key == key)
                return record;
            return null;
        }

        public static void Write(KeyValuePair<int, object> record, int blockNumber, IDbConnection dbConnection)
        {
            var records = ReplaceOrAdd(GetBlockRecords(blockNumber, dbConnection), record);
            WriteBlockRecords(records, blockNumber, dbConnection);
        }

        public static bool Delete(int key, int blockNumber, IDbConnection dbConnection)
        {
            var records = GetBlockRecords(blockNumber, dbConnection);
            var oldLength = records.Length;
            records = records.Where(el => el.Key != key).ToArray();
            if (records.Length != oldLength)
            {
                ClearBlock(blockNumber, dbConnection);
                WriteBlockRecords(records, blockNumber, dbConnection);
                return true;
            }
            return false;
        }
    }
}