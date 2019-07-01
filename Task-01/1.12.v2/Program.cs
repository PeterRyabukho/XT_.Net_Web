using System;
using System.Collections.Generic;

namespace _1._12.v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var strFirst = Console.ReadLine();
            var strSecond = Console.ReadLine();

            var charsList = new List<char>();

            char[] arr = { ' ', ',', '.', ':', ';', '!', '?', '-', '(', ')' };
            foreach (var ch in strSecond)
            {
                if (!charsList.Contains(ch))
                {
                    charsList.Add(ch);
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (charsList.Contains(arr[i]))
                        charsList.Remove(arr[i]);

                }
            }

            foreach (var ch in charsList)
            {
                strFirst = strFirst.Replace(ch.ToString(), ch.ToString() + ch.ToString());
            }

            Console.WriteLine(strFirst);
        }
    }
}
