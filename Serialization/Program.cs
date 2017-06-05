using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Meetup
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = "(Mr\\.? |Mrs\\.? |Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Mrs. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };

            foreach (var name in names)
            {
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
            }

            Console.ReadLine();

            //MyObject obj = new MyObject();
            //obj.n1 = 1;
            //obj.n2 = 24;
            //obj.str = "Some String";

            //IFormatter formatter = new BinaryFormatter();

            //Stream stream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, obj);
            //stream.Close();

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //MyObject obj = (MyObject)formatter.Deserialize(stream);
            //stream.Close();

            //// Here's the proof.  
            //Console.WriteLine("n1: {0}", obj.n1);
            //Console.WriteLine("n2: {0}", obj.n2);
            //Console.WriteLine("str: {0}", obj.str);
            //Console.Read();
        }
    }

    [Serializable]
    public class MyObject : ISerializable
    {
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;

        public MyObject()
        {

        }

        //protected MyObject(SerializationInfo info, StreamingContext context)
        //{
        //    n1 = info.GetInt32("Value1");
        //}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           // info.AddValue("Value1", n1);
            info.AddValue("Value2", n2);
            info.AddValue("Value3", str);
        }
    }
}
