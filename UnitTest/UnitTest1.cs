using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass()]
        public class AnagramTest
        {
            private const string DEFAULT_STRING = "abc";
            private const string ANAGRAM_OF_DEFAULT_STRING = "acb";
            private const string NOT_ANAGRAM_OF_DEFAULT_STRING = "abd";
            private const string SAME_ANAGRAM_SEPERATOR = ", ";
            private const string DIFFERENT_ANAGRAM_SEPERATOR = "\r\n";

            KataAnagram.AnagramList container;


            [TestInitialize()]
            public void SetUp()
            {
                container = new KataAnagram.AnagramList();
            }

            [TestMethod()]
            public void AddedStringsGetReturned()
            {
                container.Add(DEFAULT_STRING);

                Assert.AreEqual(DEFAULT_STRING, container.ToString());
            }

            [TestMethod()]
            public void StringsWhichAreAnagramsGetReturnedInSameLine()
            {
                container.Add(DEFAULT_STRING);
                container.Add(ANAGRAM_OF_DEFAULT_STRING);

                Assert.AreEqual(DEFAULT_STRING + SAME_ANAGRAM_SEPERATOR + ANAGRAM_OF_DEFAULT_STRING, container.ToString());
            }

            [TestMethod()]
            public void StringsWhichAreNotAnagramsGetReturnedInSeperateLine()
            {
                container.Add(DEFAULT_STRING);
                container.Add(NOT_ANAGRAM_OF_DEFAULT_STRING);

                Assert.AreEqual(DEFAULT_STRING + DIFFERENT_ANAGRAM_SEPERATOR + NOT_ANAGRAM_OF_DEFAULT_STRING, container.ToString());
            }
        }
    }
}



