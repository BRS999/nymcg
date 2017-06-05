using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace test
{
    [TestClass]
    public class ManipulateStringsTest
    {
        string myString = "This is my string";

        [TestMethod]
        public void StringIndex()
        {
            //	1. If we have a string called "This is my string" and we wanted to return the index of 'm' how could we do that?

            var result = myString.IndexOf("tr");

            Assert.AreEqual(result, 12);

        }

        [TestMethod]
        public void StringLastIndex()
        {
            // 2.If we have a string called "This is my string" and we wanted to return the last index of 'i' how could we do that ?
            var result = myString.LastIndexOf('i');

            Assert.AreEqual(result, 14);

        }

        [TestMethod]
        public void StringPart()
        {
            //  3.How would you return just "my" from the string "This is my string" ?

            var result = myString.Substring(8, 2);

            Assert.AreEqual("my", result);

        }

        [TestMethod]
        public void RegexStrings()
        {
            // 4. How can we remove the titles from the following names

            string pattern = "(Mr\\.? | Mrs\\.? | Miss | Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };

            foreach(var name in names)
            {
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
            }

            StringBuilder sb = new StringBuilder();


        }

        [TestMethod]
        public void StringFormattingTest()
        {
            // What are two ways to format the string as follows
            // 'a : a, b : b'
            var a = 1;
            var b = 2;

            Console.WriteLine($"a : {a}, b : {b}");
            Console.WriteLine(String.Format("a : {0}, b : {1}" , a, b));

        }

        [TestMethod]
        public void CurrencyTest()
        {
            // How can we change this double to display US currency?
            double cost = 1234.5612343;

            var result = cost.ToString("C", new System.Globalization.CultureInfo("en-UK"));

        }

        [TestMethod]
        public void SeparateWordsInString()
        {
            // How can we separate and print the words in a string?
            var result = myString.Split(' ');
            var result2 = String.Join(",", result);
            
        }

        [TestMethod]
        public void StringWriter()
        {
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }
            string xml = stringWriter.ToString();
        }
    }
}
