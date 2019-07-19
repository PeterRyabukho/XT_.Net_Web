using System;

namespace _2._1._ROUND
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = DrawRound();
            Console.WriteLine(round);
             
            //готовые значения забитые в конструктор
            //Random random = new Random();

            //Round round = new Round(random.Next(100), random.Next(100), random.Next(1,10));

            //Round someRound = new Round(4, 4, 5);

            //Console.WriteLine(round);

            //Console.WriteLine(someRound);

            Console.ReadLine();
        }
        /// <summary>
        /// UI для ввода значений в конструктор Round + создание экземпляра
        /// </summary>
        /// <returns>round=new Round(x,y,Radius);</returns>
        public static Round DrawRound()
        {
            Round round;
            Console.Write("Введите координату x: ");
            bool parse1 = int.TryParse(Console.ReadLine(), out int x);
            if (parse1)
            {
                Console.Write("Введите координату y: ");
                bool parse2 = int.TryParse(Console.ReadLine(), out int y);
                if (parse2)
                {
                    Console.Write("Введите радиус R: ");
                    bool parse3 = double.TryParse(Console.ReadLine(), out double r);
                    if (parse3 && r > 0)
                    {
                        return round = new Round(x, y, r);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!!! Введите координаты любым целым числом и радиус круга отличным от 0!");
                        DrawRound();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка!!! Введите координаты любым целым числом и радиус круга отличным от 0!");
                    DrawRound();
                }
            }
            else
            {
                Console.WriteLine("Ошибка!!! Введите координаты любым целым числом и радиус круга отличным от 0!");
                DrawRound();
            }
            return round = new Round();
        }
    }
}
