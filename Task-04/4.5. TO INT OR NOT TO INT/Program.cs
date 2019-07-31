using System;

namespace _4._5._TO_INT_OR_NOT_TO_INT
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = { "-1", "33", "534", "-777", "5", "324", "-7", "88" };

            Console.Write("Create array of string numbers: ");
            foreach (var item in str)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine("\n");

            Console.Write("Show only positive Int: ");
            foreach (var sub in str)
            {
                ShowPositiveInt(sub);
                Console.Write(" ");
            }

            Console.ReadLine();
        }

        private static void ShowPositiveInt(string str)
        {
            foreach (var item in str)
            {
                if (str.IsInThisStringNumberPositive())
                {
                    Console.Write(item);
                }
            }
        }
    }
}
