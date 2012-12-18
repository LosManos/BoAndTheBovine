using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bompare
{
    public static class Wash
    {

        public static Tuple<string, string> FromVS2012TestOutput(string input)
        {
            const string ActualString = "Actual:";
            input = input.Remove(0, "Assert.AreEqual failed. Expected:".Length);
            var pos = input.IndexOf(ActualString);
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
}
