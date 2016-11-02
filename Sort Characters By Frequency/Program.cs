//https://leetcode.com/problems/sort-characters-by-frequency/
//Accepted
//HINTs: keypair value, stringbuilder.append(char, repeats)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Characters_By_Frequency
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine(FrequencySort("yuioadfadgyuoa"));
            Console.Read();
        }

        static string FrequencySort(string s)
        {
            if (s.Equals(null) || s.Length <= 1)
            {
                return s;
            }

            StringBuilder sb = new StringBuilder();
            char[] buff = s.ToArray();
            buff = buff.OrderBy(x => x).ToArray();

            char[] disticted = buff.Distinct().ToArray();
            int[] cnt_distincted_array = new int[disticted.Length];

            int i = 0;
            foreach (char x in disticted)
            {
                cnt_distincted_array[i] = buff.Where(p => p.Equals(x)).ToArray().Length;
                i++;
            }

            var _list = new List<KeyValuePair<char, int>>(0);
            for (int j = 0; j < disticted.Length;j++ )
            {
                _list.Add(new KeyValuePair<char, int>(disticted[j], cnt_distincted_array[j]));
            }

            _list.Sort((x1, x2) => x2.Value.CompareTo(x1.Value));

            for (int j = 0; j < _list.Count; j++)
            {
                sb.Append(_list[j].Key, _list[j].Value);
            }


            return sb.ToString();
        }
    }
}
