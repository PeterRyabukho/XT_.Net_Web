using System;

namespace _1._5_Sum_Of_Numbers
{
    class Program
    {
        private static int SumOfNumbers()
        {
            int sum = 0;
            for (int i = 0; i <= 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Сумма чисел от '0 до 1000', кратная '3' или '5' " +
                              "будет равна = {0}", SumOfNumbers());

            Console.ReadKey();
        }
    }
}
