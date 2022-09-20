using System;
using System.Linq;

namespace MaxDistinctChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = args[0];
            Console.WriteLine("Initial string: " + str);

            str = GetMaxDistinctChars(str);

            Console.WriteLine();
            Console.WriteLine("Max sequence of distinct chars: " + str);

            Console.WriteLine();
            Console.Write("Press any key to close the app...");
            Console.ReadKey();
        }

        private static string GetMaxDistinctChars(string str)
        {
            string distinctChars = new(str.Distinct().ToArray());
            string[] strings = Array.Empty<string>();

            for (int i = 0; i < str.Length; i++)
            {
                string strTemp = string.Empty;
                string distinctCharsTemp = distinctChars;
                for (int j = i; j < str.Length; j++)
                {
                    if (distinctCharsTemp.Length == 0)
                    {
                        distinctCharsTemp = distinctChars;
                        strings = strings.Append(strTemp).ToArray();
                        strTemp = string.Empty;
                    }
                    if (distinctCharsTemp.Contains(str[j]))
                    {
                        strTemp += str[j];
                        distinctCharsTemp = distinctCharsTemp.Replace(str[j].ToString(), string.Empty);
                    }
                    else
                    {
                        strings = strings.Append(strTemp).ToArray();
                        strTemp = str[j].ToString();
                        distinctCharsTemp = distinctChars;
                        distinctCharsTemp = distinctCharsTemp.Replace(str[j].ToString(), string.Empty);
                    }
                }
                strings = strings.Append(strTemp).ToArray();
            }
            return strings.OrderByDescending(s => s.Length).First();
        }
    }
}
