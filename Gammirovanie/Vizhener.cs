using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gammirovanie
{
    static class Vizhener
    {
        static char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0' };

        static int N = characters.Length;

        static public string Encode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        static public string Decode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[p];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }


        private static readonly Random rand = new Random(Environment.TickCount);

        static public string Generate_Pseudorandom_KeyWord(int length)
            {
                string result = "";

                for (int i = 0; i < length; i++)
                    result += characters[rand.Next(0, characters.Length)];

                return result;
            }

        static public List<String> Key_to_KeyList(string key)
        {
            int key_length = key.Length;
            string second_key = "";
            string new_key = key;
            List<String> keys = new List<string>();

            for(int i = 0; i<9; i++)
            {
                second_key = Generate_Pseudorandom_KeyWord(key_length);

                new_key = swapSymbols(new_key, second_key, key_length);
                keys.Add(new_key);

                if (i == 0)
                {
                    if (key_length % 2 != 0)
                    {
                        keys.Add(swapSymbols(Generate_Pseudorandom_KeyWord(1)  + "" + Reverse(key), second_key, key_length + 1));
                    }  else
                    {
                        keys.Add(swapSymbols(second_key, Reverse(key), key_length));
                    }
                }
            }

            System.IO.File.WriteAllLines("SavedLists.txt", keys.ToArray());

            return keys;
        }

        static public string swapSymbols(string a, string b, int length)
        {
            char[] a_tmp = a.ToCharArray();
            char[] b_tmp = b.ToCharArray();
            for (int i = 0; i < length - 1; i += 2)
            {
                b_tmp[i] = a_tmp[i + 1];
            }

            return String.Concat(b_tmp).ToString();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
