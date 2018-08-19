using System.IO;
using Lab3.DB.Impl;

namespace Lab3.DB
{
    class DbConnection : IDbConnection
    {
        private readonly string _directoryPath;
        private FileStream _dataFileStream;
        private FileStream _indexFileStream;
        private FileStream _descriptorFileStream;
        private DbDescriptor _descriptor;

        public DbConnection() : this(Directory.GetCurrentDirectory())
        { }

        public DbConnection(string directoryPath)
        {
            _directoryPath = directoryPath;
            InitDirectory();
            InitDescriptor();
            InitIndexFileStream();
            InitDataFileStream();
        }

        private void InitDirectory()
        {
            var directoryInfo = new DirectoryInfo(_directoryPath);
            directoryInfo.Create();
        }

        private void InitDescriptor()
        {
            var descriptorFilePath = string.Join("\\", _directoryPath, "db.descriptor");
            bool exists = File.Exists(descriptorFilePath);
            _descriptorFileStream = new FileStream(descriptorFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            if (exists)
            {
                _descriptor = DbDescriptorFileUtility.Read(_descriptorFileStream);
            }
            else
            {
                _descriptor = new DbDescriptor();
            }
        }

        private void InitDataFileStream()
        {
            var dataFilePath = string.Join("//", _directoryPath, "data.dat");
            _dataFileStream = new FileStream(dataFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        }

        private void InitIndexFileStream()
        {
            var indexFilePath = string.Join("//", _directoryPath, "data.index");
            _indexFileStream = new FileStream(indexFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        }

        public FileStream GetIndexFileStream()
        {
            return _indexFileStream;
        }

        public FileStream GetDataFileStream()
        {
            return _dataFileStream;
        }

        public DbDescriptor GetDescriptor()
        {
            return _descriptor;
        }

        public IDbManager GetManager()
        {
            return new DbManager(this);
        }

        public void Dispose()
        {
            DbDescriptorFileUtility.Write(_descriptorFileStream, _descriptor);
            _descriptorFileStream.Close();
            _indexFileStream.Close();
            _dataFileStream.Close();
            _descriptor = null;
        }
    }
}
