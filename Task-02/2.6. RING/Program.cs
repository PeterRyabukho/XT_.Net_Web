using System;

namespace _2._6._RING
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = DrawRound();
            Console.WriteLine(ring);

            Console.ReadLine();
        }

        #region UI DrawRound
        public static Ring DrawRound()
        {
            Ring round;
            Console.Write("Введите координату x: ");
            bool parse1 = int.TryParse(Console.ReadLine(), out int x);
            if (parse1)
            {
                Console.Write("Введите координату y: ");
                bool parse2 = int.TryParse(Console.ReadLine(), out int y);
                if (parse2)
                {
                    Console.Write("Введите внешний радиус R: ");
                    bool parse3 = double.TryParse(Console.ReadLine(), out double radius);
                    if (parse3 && radius > 0)
                    {
                        Console.Write("Введите внутренний радиус r: ");
                        bool parse4 = double.TryParse(Console.ReadLine(), out double ineerRadius);
                        if (parse3 && ineerRadius > 0)
                        {
                            return round = new Ring(x, y, radius, ineerRadius);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!!! Введите координаты любым целым числом и радиусы кольца отличным от 0!");
                        DrawRound();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка!!! Введите координаты любым целым числом и радиусы кольца отличным от 0!");
                    DrawRound();
                }
            }
            else
            {
                Console.WriteLine("Ошибка!!! Введите координаты любым целым числом и радиусы кольца отличным от 0!");
                DrawRound();
            }
            return round = new Ring();
        }
        #endregion
    }
}
