using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{

    public delegate void Int32Action(int value);

    public delegate void GenericAction<T>(T value);

    [TestClass]
    public class UnitTest2
    {
        private void MethodTakingString(string value)
        {
            System.Console.WriteLine(value);
        }

        [TestMethod]
        public void TestMethod1()
        {
            GenericAction<string> action = MethodTakingString;
            action("Hi!");
        }

        [TestMethod]
        public void AnonMethod()
        {

            List<int> original = new List<int> { 1, 2, 3 };

            original.Select(x => Math.Sqrt(x))
            .ToList()
            .ForEach(x => Console.WriteLine(x));

        }

        [TestMethod]
        public void EncodedString()
        {

            using (var md5 = MD5.Create())
            {

                byte[] hash = md5.ComputeHash(new byte[10]);

                string hashAsText = Convert.ToBase64String(hash);

                byte[] backAgain = Convert.FromBase64String(hashAsText);

                CollectionAssert.AreEqual(hash, backAgain);
            }
        }

        [TestMethod]
        public void FileWrite()
        {

            File.WriteAllText(@"C:\Users\ben\Source\Repos\meetup\test\test.txt", "Hello world");
        }

        [TestMethod]
        public void FredList()
        {
            List<string> names = new List<string>();

            names.Add("Fred");

            Assert.AreEqual("Fred", names[0]);
            Assert.AreEqual(1, names.Count());

            var numbers = new List<int>(50) { 10, 50 };

            Assert.AreEqual(10, numbers[0]);

        }

        [TestMethod]
        public void DictionaryTest()
        {

            //Looking up things quickly

            var map = new Dictionary<string, int>();

            map.Add("foo", 10);
            map["bar"] = 20;

            var ninja = new Dictionary<string, int>()
            {
                {"hello", 1},
                {"world", 2}
            };

            foreach (var item in map)
            {
                System.Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}
