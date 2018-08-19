using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab3.DB.Impl
{
    class DbIndexFileUtility
    {
        public static IndexRecord[] GetBlockRecords(long blockNumber, IDbConnection dbConnection)
        {
            var records = new List<IndexRecord>();
            var descriptor = dbConnection.GetDescriptor();
            var formatter = new BinaryFormatter();
            var fs = dbConnection.GetIndexFileStream();
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
                        records.Add((IndexRecord)formatter.Deserialize(stream));
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            }
            return records.ToArray();
        }

        private static IndexRecord[] FindIndexRecordBlock(int key, IDbConnection dbConnection)
        {
            var descriptor = dbConnection.GetDescriptor();
            var indexRecordsInBlock = descriptor.BlockSize / descriptor.IndexRecordSize;
            var indexBlocksCount = descriptor.DataBlocksCount / indexRecordsInBlock;
            long n = indexBlocksCount;
            if (n == 0)
            {
                return GetBlockRecords(0, dbConnection);
            }
            long k = (long)Math.Log(n, 2) - 1;
            long i = (long)Math.Pow(2, k);

            var block = GetBlockRecords(i, dbConnection);
            if (key > block.Last().Key)
            {
                int l = (int)Math.Log(n - i + 1, 2);
                i = n + 1 - (int)Math.Pow(2, l);
                k = l;
                block = GetBlockRecords(i, dbConnection);
            }
            int offset = (int)Math.Pow(2, k - 1);
            while (offset != 0)
            {
                if (block.First().Key <= key && block.Last().Key >= key)
                    return block;
                if (block.First().Key > key)
                    i -= offset;
                else
                    i += offset;
                offset /= 2;
                block = GetBlockRecords(i, dbConnection);
            }
            if (block.First().Key <= key && block.Last().Key >= key)
                return block;
            if (block.First().Key > key)
                return GetBlockRecords(i - 1, dbConnection);
            return GetBlockRecords(i + 1, dbConnection);
        }

        private static IndexRecord[] FindIndexRecordBlockWithStatistic(int key, IDbConnection dbConnection, ref int comparasions)
        {
            var descriptor = dbConnection.GetDescriptor();
            var indexRecordsInBlock = descriptor.BlockSize / descriptor.IndexRecordSize;
            var indexBlocksCount = descriptor.DataBlocksCount / indexRecordsInBlock;
            long n = indexBlocksCount;
            if (n == 0)
            {
                return GetBlockRecords(0, dbConnection);
            }
            long k = (long)Math.Log(n, 2) - 1;
            long i = (long)Math.Pow(2, k);

            var block = GetBlockRecords(i, dbConnection);
            comparasions++;
            if (key > block.Last().Key)
            {
                int l = (int)Math.Log(n - i + 1, 2);
                i = n + 1 - (int)Math.Pow(2, l);
                k = l;
                block = GetBlockRecords(i, dbConnection);
            }
            int offset = (int)Math.Pow(2, k - 1);
            while (offset != 0)
            {
                comparasions++;
                if (block.First().Key <= key && block.Last().Key >= key)
                    return block;
                comparasions++;
                if (block.First().Key > key)
                    i -= offset;
                else
                    i += offset;
                offset /= 2;
                block = GetBlockRecords(i, dbConnection);
            }
            comparasions++;
            if (block.First().Key <= key && block.Last().Key >= key)
                return block;
            comparasions++;
            if (block.First().Key > key)
                return GetBlockRecords(i - 1, dbConnection);
            return GetBlockRecords(i + 1, dbConnection);
        }

        public static void Rewrite(IndexRecord[] indexes, IDbConnection dbConnection)
        {
            var descriptor = dbConnection.GetDescriptor();
            var indexRecordsInBlock = descriptor.BlockSize / descriptor.IndexRecordSize;
            var indexBlocksCount =  indexes.Length / indexRecordsInBlock;
            if (indexes.Length % indexRecordsInBlock > 0 || indexBlocksCount == 0)
                ++indexBlocksCount;
            var formatter = new BinaryFormatter();
            var fs = dbConnection.GetIndexFileStream();
            fs.SetLength(0);
            fs.Flush();
            var curRecord = 0;
            for (int block = 0; block < indexBlocksCount; ++block)
            {
                fs.Position = block * descriptor.BlockSize;
                for (int i = 0; i < indexRecordsInBlock && curRecord < indexes.Length; ++i)
                {
                    formatter.Serialize(fs, indexes[curRecord]);
                    curRecord++;
                }
            }
        }

        public static int FindDataBlockNumber(int key, IDbConnection dbConnection)
        {
            var records = FindIndexRecordBlock(key, dbConnection);

            var record = records[0];
            if (record.Key == key)
                return record.Block;
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
                    return record.Block;
                if (record.Key > key)
                    i -= offset;
                else
                    i += offset;
                offset /= 2;
                record = records[i];
            }
            return record.Key <= key ? record.Block : records[i-1].Block;
        }

        public static int FindDataBlockNumberWithStatistic(int key, IDbConnection dbConnection, ref int comparasions)
        {
            var records = FindIndexRecordBlockWithStatistic(key, dbConnection, ref comparasions);

            var record = records[0];
            comparasions++;
            if (record.Key == key)
                return record.Block;
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
                    return record.Block;
                comparasions++;
                if (record.Key > key)
                    i -= offset;
                else
                    i += offset;
                offset /= 2;
                record = records[i];
            }
            comparasions++;
            return record.Key <= key ? record.Block : records[i - 1].Block;
        }

        
    }
}
