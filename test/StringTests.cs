using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace test
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue("hello" == "hello");
            Assert.AreEqual("hello", "hello");
        }
        
        [TestMethod]
        public void PracticeTest() {

            Assert.IsTrue('a'.isVowel());
            Assert.IsTrue('u'.isVowel());
        }

    }

    public static class SomethingAwesome
    {
        public static int Cube(this int x)
        {
            return x * x * x;
        }

        public static bool isVowel(this char vow)
        {
            return Array.Exists
            (
                new char[] {'a','e','i','o','u'}, x => x.Equals(vow)
            );
        }
    }   
}
