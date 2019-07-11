using System;

namespace _2._1._ROUND
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Round round = new Round(random.Next(100), random.Next(100), random.Next(1,10));

            Round someRound = new Round(4, 4, 5);

            Console.WriteLine(round);

            Console.WriteLine(someRound);

            Console.ReadLine();
        }

        //private Round DrawRound()
        //{
        //    Console.Write("Введите координату x: ");
        //    bool parse1 = int.TryParse(Console.ReadLine(), out int x);
        //    if (parse1)
        //    {
        //        Console.Write("Введите координату y: ");
        //        bool parse2 = int.TryParse(Console.ReadLine(), out int y);
        //        if (parse2)
        //        {
        //            Console.Write("Введите радиус R: ");
        //            bool parse3 = double.TryParse(Console.ReadLine(), out double r);
        //            if (parse3 && r > 0)
        //            {
        //                return round = new Round(x, y, r);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ошибка!!! Введите координаты любым целым числом и радиус круга отличным от 0!");

        //    }
        //}
    }
}
