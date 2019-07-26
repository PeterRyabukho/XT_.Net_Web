using System;

namespace _4._4._NUMBER_ARRAY_SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSumm((x, y) => { var sum = x + y; return sum; }, 3.88, 5));


            Console.ReadKey();
        }

        public static T GetSumm<T>(Func<T, T, T> summ, T x, T y)
        {
            return summ(x, y);
        }
    }
}
