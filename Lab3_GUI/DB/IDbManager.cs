using System;
using System.Collections.Generic;

namespace Lab3.DB
{
    public interface IDbManager : IDisposable
    {
        void Write(int key, object value);
        void Write(KeyValuePair<int, object> record);
        void RewriteWithIndexRebuild(SortedDictionary<int, object> data);
        KeyValuePair<int, object>? Read(int key);
        KeyValuePair<int, object>? ReadWithStatistic(int key, out int comparasions);
        bool Delete(int key);
    }
}