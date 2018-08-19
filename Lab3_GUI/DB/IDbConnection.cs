using System;
using System.IO;

namespace Lab3.DB
{
    public interface IDbConnection : IDisposable
    {
        IDbManager GetManager();
        FileStream GetDataFileStream();
        FileStream GetIndexFileStream();
        DbDescriptor GetDescriptor();
    }
}
