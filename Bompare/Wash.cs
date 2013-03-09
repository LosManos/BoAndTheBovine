using System;

namespace Bompare
{
    public static class Wash
    {
        public const string ComparisonResultStartsWith = "Assert.AreEqual failed. Expected:";
        //  Suddenly, with web essentials 2012?, the result looked differently.  I call it Type2 for now.
        public const string UnitTestResultType2StartsWith = "Test Name:";

        public static Tuple<string, string> FromVS2012TestOutput(string input)
        {
            const string ActualString = "Actual:";
            input = input.Remove(0, ComparisonResultStartsWith.Length);
            var pos = input.IndexOf(ActualString, StringComparison.Ordinal);
            var expectedString = input.Substring(0, pos);
            expectedString = expectedString.Remove(0, 1).Remove(expectedString.Length - 4, 3);
            var actualString = input.Substring(pos + ActualString.Length, input.Length - pos - ActualString.Length);
            actualString = actualString.Remove(0, 1).Remove(actualString.Length - 3, 2);
            return new Tuple<string, string>(
                expectedString,
                actualString
            );
        }
    }

    //public class ExpectedActualPair
    //{
    //    public string Expected { get; set; }
    //    public string Actual { get; set; }

    //    public static ExpectedActualPair Create(string expected, string actual)
    //    {
    //        return new ExpectedActualPair().Set(expected, actual);
    //    }

    //    private ExpectedActualPair Set(string expected, string actual)
    //    {
    //        this.Expected = expected;
    //        this.Actual = actual;
    //        return this;
    //    }
    //}
}
