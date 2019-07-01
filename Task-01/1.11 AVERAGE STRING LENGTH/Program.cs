using System;

namespace _1._11_AVERAGE_STRING_LENGTH
{
    class Program
    {
        private static int lengthCount(string str)
        {
            string[] arr = str.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?', '-', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int wordLength = 0;
            foreach (string item in arr)
            {
                wordLength += item.Length;
            }
            
            return wordLength / arr.Length;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            string str = Console.ReadLine();

            Console.WriteLine("Средняя длинна слова в этом предложении - {0}", lengthCount(str));

            Console.ReadKey();
        }
    }
}
