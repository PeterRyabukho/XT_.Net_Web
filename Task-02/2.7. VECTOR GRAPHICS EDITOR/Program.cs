using System;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point p1 = new Point(-2, 4);
            //Point p2 = new Point(5, 2);
            //Line line = new Line(p1, p2);
            //Console.WriteLine(line);

            int enter = YourFigure();
            switch(enter)
            {
                case 1:
                    DrawCircle();
                    break;
            }
            Console.ReadLine();
        }

        private static int YourFigure()
        {
            Console.WriteLine($"Выберите фигуру: \n\t1. Окружность.\n\t2. Круг\n\t3. Кольцо.\n\t4. Линия.\n\t5. Прямоугольник.\n");
            Console.Write("Для выбора введите цифру от 1 до 5: ");
            bool b = Int32.TryParse(Console.ReadLine(), out int N);
            if(b & N>0 & N<6)
            {
                return N;
            }
            else
            {
                Console.WriteLine("Ошибка! Для выбора возможно вводить цифры только от 1-6!\n");
                YourFigure();
                return 0;
            }
        }

        private static void DrawCircle()
        {
            Console.Write("Введите координату X: ");
            if(int.TryParse(Console.ReadLine(), out int X))
            {
                Console.Write("Введите координату Y: ");
                if (int.TryParse(Console.ReadLine(), out int Y))
                {
                    Console.Write("Введите радиус: ");
                    if (int.TryParse(Console.ReadLine(), out int R))
                    {
                        RoundShape roundShape = new RoundShape(X, Y, R);
                        Console.WriteLine(roundShape);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите число!\n");
                        DrawCircle();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число!\n");
                    DrawCircle();
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите число!\n");
                DrawCircle();
            }
        }
    }
}
