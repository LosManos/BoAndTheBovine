using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bompare
{
    public static class Compare
    {
        public static CompareResult Execute(string s1, string s2)
        {
            //  Both arguments are null.  Alas equal.
            if (null == s1 && null == s2)
            {
                return CompareResult.Create(new List<CompareResult.StringDifferencePair>());
            }

            //  Only one argument is null.  Not equal then.
            if (null == s1 || null == s2)
            {
                return CompareResult.Create(new List<CompareResult.StringDifferencePair>()
                    {
                        CompareResult.StringDifferencePair.Create( false, s1, s2 )
                    });
            }

            if (s1 == s2)
            {
                return CompareResult.Create(new List<CompareResult.StringDifferencePair>()
                    {
                        CompareResult.StringDifferencePair.Create( true, s1, s2 )
                    });
            }

            var diffList = new List<CompareResult.StringDifferencePair>();
            var str1 = string.Empty;
            var str2 = string.Empty;
            var similar = new Nullable<bool>();
            for (var index = 0; index < Math.Min(s1.Length, s2.Length); ++index)
            {

                if (similar.HasValue)
                {

                    if (s1[index] == s2[index])
                    {
                        if (similar.Value)
                        {
                            str1 += s1[index];
                            str2 += s2[index];
                        }
                        else
                        {
                            diffList.Add(CompareResult.StringDifferencePair.Create(false, str1, str2));
                            str1 = s1[index].ToString();
                            str2 = s2[index].ToString();
                        }
                    }
                    else if (similar.Value)
                    {
                        diffList.Add(CompareResult.StringDifferencePair.Create(str1 == str2, str1, str2));
                        str1 = s1[index].ToString();
                        str2 = s2[index].ToString();
                    }
                    else
                    {
                        str1 += s1[index];
                        str2 += s2[index];
                    }
                }
                else
                {
                    //  First time.
                    str1 += s1[index];
                    str2 += s2[index];
                }

                similar = s1[index] == s2[index];
            }

            if (false == string.IsNullOrEmpty(s1))
            {
                str1 = str1 + s1.Substring(Math.Min(s1.Length, s2.Length));
                str2 = str2 + s2.Substring(Math.Min(s1.Length, s2.Length));
                diffList.Add(CompareResult.StringDifferencePair.Create(str1 == str2, str1, str2));
            }

            return CompareResult.Create(diffList);
        }
    }
}
