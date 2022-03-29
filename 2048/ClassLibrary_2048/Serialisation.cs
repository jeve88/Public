using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_2048
{
    public class Serialisation
    {
        public static void Serialize(Grille _save, string _path)
        {
            Stream ms = File.OpenWrite(_path);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, _save);

            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static Grille Deserialize(string _path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(_path, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            Grille save = (Grille)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();

            return save;
        }

        public static void SerializeList(List<Grille> _save, string _path)
        {
            Stream ms = File.OpenWrite(_path);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, _save);

            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static List<Grille> DeserializeList(string _path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(_path, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            List<Grille> save = (List<Grille>)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();

            return save;
        }
    }
}
