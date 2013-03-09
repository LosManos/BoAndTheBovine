using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BompareTest
{
    [TestClass]
    public class WashTest
    {

        [TestMethod]
        public void FromVS2012TestOutput()
        {
            var input = "Assert.AreEqual failed. Expected:<XXX>. Actual:<YYY>.";

            var res = Bompare.Wash.FromVS2012TestOutput( input );

            Assert.AreEqual( "XXX", res.Item1 );
            Assert.AreEqual( "YYY", res.Item2 );

            input = "Assert.AreEqual failed. Expected:<Eating cows is like<br/>eating a part of your<br/>soul.<br/><br/>- <a href=\"http://example.com/\" target=\"_blank\">http://example.com/</a>&nbsp;&nbsp;&lt;- with comment<br/>- <a href=\"http://example2.com/withoutcomment.aspx?id=42\" target=\"_blank\">http://example2.com/withoutcomment.aspx?id=42</a>>. Actual:<Eating cows is like<br/>eating a part of your<br/>soul.<br/><br/>- <a href=\"http://example.com/\" target=\"_blank\">http://example.com/</a>		<- with comment<br/><a href=\"http://example2.com/withoutcomment.aspx?id=42\" target=\"_blank\">http://example2.com/withoutcomment.aspx?id=42</a>>.";

            res = Bompare.Wash.FromVS2012TestOutput(input);

            Assert.AreEqual(
                "Eating cows is like<br/>eating a part of your<br/>soul.<br/><br/>- <a href=\"http://example.com/\" target=\"_blank\">http://example.com/</a>&nbsp;&nbsp;&lt;- with comment<br/>- <a href=\"http://example2.com/withoutcomment.aspx?id=42\" target=\"_blank\">http://example2.com/withoutcomment.aspx?id=42</a>", 
                res.Item1);
            Assert.AreEqual(
                "Eating cows is like<br/>eating a part of your<br/>soul.<br/><br/>- <a href=\"http://example.com/\" target=\"_blank\">http://example.com/</a>		<- with comment<br/><a href=\"http://example2.com/withoutcomment.aspx?id=42\" target=\"_blank\">http://example2.com/withoutcomment.aspx?id=42</a>", 
                res.Item2);
        }

//        [TestMethod]
//        public void FromVS2012TestOutputV2()
//        {
//            const string Input = @"Test Name:	ProperMerge
//Test FullName:	EverCoow.UnitTest.DoTest.ProperMerge
//Test Source:	\\psf\home\Documents\Development\Projects\EverCoow\EverCoow.Net\EverCoow\EverCoow.UnitTest\DoTest.cs : line 78
//Test Outcome:	Failed
//Test Duration:	0:00:01,7588437
//Result Message:	Assert.AreEqual failed. Expected:<XXX>.Actual<YYY>.";

//            var res = Bompare.Wash.FromVS2012TestOutput(Input);

//            Assert.AreEqual("XXX", res.Item1);
//            Assert.AreEqual("YYY", res.Item2);            
//        }
    }
}
