using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bompare
{
    public class CompareResult
    {
        public class StringDifferencePair
        {
            public string Text1 { get; private set; }
            public string Text2 { get; private set; }
            public bool Similar { get; private set; }

            internal static StringDifferencePair Create(bool similar, string text1, string text2)
            {
                return Set(similar, text1, text2);
            }

            private static StringDifferencePair Set(bool similar, string text1, string text2)
            {
                return new StringDifferencePair()
                {
                    Similar = similar,
                    Text1 = text1,
                    Text2 = text2
                };
            }
        }

        public bool Similar { get; private set; }

        public IList<StringDifferencePair> StringDifferenceList { get; private set; }

        internal static CompareResult Create(IList<StringDifferencePair> stringDifferenceEnumerable)
        {
            return Set(
                stringDifferenceEnumerable.All(sd => sd.Similar), 
                stringDifferenceEnumerable
            );
        }

        private static CompareResult Set(bool similar, IList<StringDifferencePair> stringDifferenceEnumerable)
        {
            return new CompareResult()
            {
                Similar = similar, 
                StringDifferenceList = stringDifferenceEnumerable
            };
        }
    }
}
