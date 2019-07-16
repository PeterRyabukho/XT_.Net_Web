using System;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doIt = true;
            while (doIt)
            {
                int enter = YourFigure();
                switch (enter)
                {
                    case 1:
                        DrawRound();
                        break;
                    case 2:
                        DrawCircle();
                        break;
                    case 3:
                        DrawRing();
                        break;
                    case 4:
                        DrawLine();
                        break;
                    case 5:
                        DrawRectangle();
                        break;
                }
                Console.WriteLine("\nЖелаете построить другую фигуру да/нет? Нажмите клавишу 'y'/'n' соответственно.");
                ConsoleKeyInfo btn = Console.ReadKey();
                if(btn.Key==ConsoleKey.N)
                {
                    doIt = false;
                }
            }

            Console.ReadLine();
        }

        #region YourFigure()
        private static int YourFigure()
        {
            Console.WriteLine($"\nВыберите фигуру: \n\t1. Окружность.\n\t2. Круг\n\t3. Кольцо.\n\t4. Линия.\n\t5. Прямоугольник.\n");
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
        #endregion

        #region DrawRound()
        private static void DrawRound()
        {
            Console.Write("\nВведите координату X: ");
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
                        DrawRound();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число!\n");
                    DrawRound();
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите число!\n");
                DrawRound();
            }
        }
        #endregion

        #region DrawCircle()
        private static void DrawCircle()
        {
            Console.Write("\nВведите координату X: ");
            if (int.TryParse(Console.ReadLine(), out int X))
            {
                Console.Write("Введите координату Y: ");
                if (int.TryParse(Console.ReadLine(), out int Y))
                {
                    Console.Write("Введите радиус: ");
                    if (int.TryParse(Console.ReadLine(), out int R))
                    {
                        RoundShape circle = new Circle(X, Y, R);
                        Console.WriteLine(circle);
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
        #endregion

        #region DrawRing()
        private static void DrawRing()
        {
            Console.Write("\nВведите координату X: ");
            if (int.TryParse(Console.ReadLine(), out int X))
            {
                Console.Write("Введите координату Y: ");
                if (int.TryParse(Console.ReadLine(), out int Y))
                {
                    Console.Write("Введите радиус: ");
                    if (int.TryParse(Console.ReadLine(), out int R))
                    {
                        Console.Write("Введите внутренний радиус: ");
                        if (int.TryParse(Console.ReadLine(), out int innerR))
                        {
                            RoundShape ring = new Ring(X, Y, R, innerR);
                            Console.WriteLine(ring);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Введите число!\n");
                            DrawRing();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите число!\n");
                        DrawRing();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число!\n");
                    DrawRing();
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите число!\n");
                DrawRing();
            }
        }
        #endregion

        #region DrawLine()
        private static void DrawLine()
        {
            Console.WriteLine("\nОпределите начальную точку");
            Console.Write("Введите координату X-1: ");
            if (int.TryParse(Console.ReadLine(), out int X1))
            {
                Console.Write("Введите координату Y-1: ");
                if (int.TryParse(Console.ReadLine(), out int Y1))
                {
                    Console.WriteLine("\nОпределите конечную точку");
                    Console.Write("Введите координату X-2: ");
                    if (int.TryParse(Console.ReadLine(), out int X2))
                    {
                        Console.Write("Введите координату Y-2: ");
                        if (int.TryParse(Console.ReadLine(), out int Y2))
                        {
                            Point startPoint = new Point(X1, Y1);
                            Point endPoint = new Point(X2, Y2);
                            Figure line = new Line(startPoint, endPoint);
                            Console.WriteLine(line);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Введите число!\n");
                            DrawLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите число!\n");
                        DrawLine();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число!\n");
                    DrawLine();
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите число!\n");
                DrawLine();
            }
        }
        #endregion

        #region DrawRectangle()
        private static void DrawRectangle()
        {
            Console.Write("\nВведите координату X: ");
            if (int.TryParse(Console.ReadLine(), out int X))
            {
                Console.Write("Введите координату Y: ");
                if (int.TryParse(Console.ReadLine(), out int Y))
                {
                    Console.Write("Введите высоту прямоугольника: ");
                    if (int.TryParse(Console.ReadLine(), out int H))
                    {
                        Console.Write("Введите ширину прямоугольника: ");
                        if (int.TryParse(Console.ReadLine(), out int W))
                        {
                            Figure rectangle = new Rectangle(W, H, X, Y);
                            Console.WriteLine(rectangle);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите число!\n");
                        DrawRectangle();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число!\n");
                    DrawRectangle();
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите число!\n");
                DrawRectangle();
            }
        }
        #endregion
    }
}
