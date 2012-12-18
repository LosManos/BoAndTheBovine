using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BompareTest
{
    [TestClass]
    public class CompareTest
    {
        [TestMethod]
        public void Simple()
        {
            var res = Bompare.Compare.Execute(null, null);
            Assert.AreEqual(true, res.Similar);
            Assert.AreEqual(0, res.StringDifferenceList.Count);

            res = Bompare.Compare.Execute( null, "");
            Assert.AreEqual(false, res.Similar);
            Assert.AreEqual(1, res.StringDifferenceList.Count);
            Assert.AreEqual(null, res.StringDifferenceList[0].Text1);
            Assert.AreEqual("", res.StringDifferenceList[0].Text2);

            res = Bompare.Compare.Execute("", null);
            Assert.AreEqual(false, res.Similar);
            Assert.AreEqual(1, res.StringDifferenceList.Count);
            Assert.AreEqual("", res.StringDifferenceList[0].Text1);
            Assert.AreEqual(null, res.StringDifferenceList[0].Text2);

            res = Bompare.Compare.Execute("", "");
            Assert.AreEqual(true, res.Similar);
            Assert.AreEqual(1, res.StringDifferenceList.Count);
            Assert.AreEqual("", res.StringDifferenceList[0].Text1);
            Assert.AreEqual("", res.StringDifferenceList[0].Text2);

            res = Bompare.Compare.Execute("a", "a");
            Assert.AreEqual(true, res.Similar);
            Assert.AreEqual(1, res.StringDifferenceList.Count);
            Assert.AreEqual("a", res.StringDifferenceList[0].Text1);
            Assert.AreEqual("a", res.StringDifferenceList[0].Text2);

            res = Bompare.Compare.Execute("a", "b");
            Assert.AreEqual(false, res.Similar);
            Assert.AreEqual(1, res.StringDifferenceList.Count);
            Assert.AreEqual("a", res.StringDifferenceList[0].Text1);
            Assert.AreEqual("b", res.StringDifferenceList[0].Text2);

            res = Bompare.Compare.Execute("aa", "ab");
            Assert.AreEqual(false, res.Similar);
            Assert.AreEqual(2, res.StringDifferenceList.Count);
            Assert.AreEqual(true, res.StringDifferenceList[0].Similar);
            Assert.AreEqual("a", res.StringDifferenceList[0].Text1);
            Assert.AreEqual("a", res.StringDifferenceList[0].Text2);
            Assert.AreEqual(false, res.StringDifferenceList[1].Similar);
            Assert.AreEqual("a", res.StringDifferenceList[1].Text1);
            Assert.AreEqual("b", res.StringDifferenceList[1].Text2);

            res = Bompare.Compare.Execute("aa", "ba");
            Assert.AreEqual(false, res.Similar);
            Assert.AreEqual(2, res.StringDifferenceList.Count);
            Assert.AreEqual(false, res.StringDifferenceList[0].Similar);
            Assert.AreEqual("a", res.StringDifferenceList[0].Text1);
            Assert.AreEqual("b", res.StringDifferenceList[0].Text2);
            Assert.AreEqual(true, res.StringDifferenceList[1].Similar);
            Assert.AreEqual("a", res.StringDifferenceList[1].Text1);
            Assert.AreEqual("a", res.StringDifferenceList[1].Text2);

            res = Bompare.Compare.Execute("abc", "cba");
            Assert.AreEqual(false, res.Similar);
            Assert.AreEqual(3, res.StringDifferenceList.Count);
            Assert.AreEqual(false, res.StringDifferenceList[0].Similar);
            Assert.AreEqual("a", res.StringDifferenceList[0].Text1);
            Assert.AreEqual("c", res.StringDifferenceList[0].Text2);
            Assert.AreEqual(true, res.StringDifferenceList[1].Similar);
            Assert.AreEqual("b", res.StringDifferenceList[1].Text1);
            Assert.AreEqual("b", res.StringDifferenceList[1].Text2);
            Assert.AreEqual(false, res.StringDifferenceList[2].Similar);
            Assert.AreEqual("c", res.StringDifferenceList[2].Text1);
            Assert.AreEqual("a", res.StringDifferenceList[2].Text2);

            res = Bompare.Compare.Execute("MySimilarSentenceWorking", "NoSimilarFully");
            Assert.AreEqual(false, res.Similar);
            Assert.AreEqual(3, res.StringDifferenceList.Count);
            Assert.AreEqual(false, res.StringDifferenceList[0].Similar);
            Assert.AreEqual("My", res.StringDifferenceList[0].Text1);
            Assert.AreEqual("No", res.StringDifferenceList[0].Text2);
            Assert.AreEqual(true, res.StringDifferenceList[1].Similar);
            Assert.AreEqual("Similar", res.StringDifferenceList[1].Text1);
            Assert.AreEqual("Similar", res.StringDifferenceList[1].Text2);
            Assert.AreEqual(false, res.StringDifferenceList[2].Similar);
            Assert.AreEqual("SentenceWorking", res.StringDifferenceList[2].Text1);
            Assert.AreEqual("Fully", res.StringDifferenceList[2].Text2);
        }
    }

}
