using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab3.DB.Impl
{
    internal class DbDescriptorFileUtility
    {
        public static DbDescriptor Read(FileStream fileStream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            var descriptor = (DbDescriptor)formatter.Deserialize(fileStream);
            fileStream.Position = 0;
            return descriptor;
        }

        public static void Write(FileStream fileStream, DbDescriptor descriptor)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, descriptor);
            fileStream.Position = 0;
        }
    }
}
