using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Lab3.DB;

namespace Lab3.DB.Impl
{
    class DbManager : IDbManager
    {
        private IDbConnection _dbConnection;

        public DbManager(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Write(int key, object value)
        {
            var dataBlockNumber = DbIndexFileUtility.FindDataBlockNumber(key, _dbConnection);
            DbDataFileUtility.Write(new KeyValuePair<int, object>(key, value), dataBlockNumber, _dbConnection);
        }

        public void Write(KeyValuePair<int, object> record)
        {
            var dataBlockNumber = DbIndexFileUtility.FindDataBlockNumber(record.Key, _dbConnection);
            DbDataFileUtility.Write(record, dataBlockNumber, _dbConnection);
        }

        public void RewriteWithIndexRebuild(SortedDictionary<int, object> data)
        {
            if (!data.Any())
                return;
            var indexes = DbDataFileUtility.RewriteWithIndexRebuild(data, _dbConnection);
            DbIndexFileUtility.Rewrite(indexes, _dbConnection);
        }

        public KeyValuePair<int, object>? Read(int key)
        {
            var dataBlockNumber = DbIndexFileUtility.FindDataBlockNumber(key, _dbConnection);
            return DbDataFileUtility.FindRecord(key, dataBlockNumber, _dbConnection);
        }

        public KeyValuePair<int, object>? ReadWithStatistic(int key, out int comparasions)
        {
            comparasions = 0;
            var dataBlockNumber = DbIndexFileUtility.FindDataBlockNumberWithStatistic(key, _dbConnection, ref comparasions);
            return DbDataFileUtility.FindRecordWithStatistic(key, dataBlockNumber, _dbConnection, ref comparasions);
        }

        public bool Delete(int key)
        {
            var dataBlockNumber = DbIndexFileUtility.FindDataBlockNumber(key, _dbConnection);
            return DbDataFileUtility.Delete(key, dataBlockNumber, _dbConnection);
        }

        public void Dispose()
        {
            _dbConnection = null;
        }
    }
}
