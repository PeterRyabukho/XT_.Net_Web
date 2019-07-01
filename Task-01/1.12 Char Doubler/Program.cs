using System;
using System.Collections.Generic;

namespace _1._12_Char_Doubler
{
    class Program
    {
        private static string getDoubler(string firstStr, string secStr)
        {
            List<char> charsList = new List<char>();

            string newStr = "";

            char[] arr = { ' ', ',', '.', ':', ';', '!', '?', '-', '(', ')' };
            foreach (char ch in secStr)
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

            foreach (char ch in charsList)
            {
                newStr = firstStr.Replace(ch.ToString(), ch.ToString() + ch.ToString());
            }

            return newStr;
        }

        static void Main(string[] args)
        {
            Console.Write("Введи первую строку: ");
            string firstStr = Console.ReadLine();
            Console.Write("Введи вторую строку: ");
            string secStr = Console.ReadLine();

            Console.Write("Результирующая строка: {0}", getDoubler(firstStr, secStr));

            Console.ReadKey();
        }
    }
}
