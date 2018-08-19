using System;

namespace Lab3.DB
{
    [Serializable]
    public class DbDescriptor
    {
        public int BlockSize { get; set; }
        public long DataBlocksCount { get; set; }
        public long RecordSize { get; set; }
        public long IndexRecordSize { get; set; }
        public long LinkSize { get; set; }
        public int FillFactor { get; set; }
        public int OverloadSize { get; set; }

        public DbDescriptor()
        {
            BlockSize = 4096;
            FillFactor = 80;
            LinkSize = 54;
        }
    }
}
