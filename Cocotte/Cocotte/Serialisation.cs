using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Cocotte
{
    class Serialisation
    {
        public static void SerializeMessages(string[] _messages, string _path)
        {
            Stream ms = File.OpenWrite(_path);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, _messages);

            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static string[] DeserializeMessages(string _path)
        { 
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(_path, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            string[] messages = (string[])obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();

            return messages;
        }
    }
}
