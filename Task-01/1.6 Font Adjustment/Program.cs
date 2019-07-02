using System;


namespace _1._6_Font_Adjustment
{
    class Program
    {
        private static Font getFont(ref Font newFont, int N)
        {
            switch (N)
            {
                case 1:
                    if (newFont == Font.None)
                        newFont = Font.Bold;
                    else newFont = newFont ^ Font.Bold;
                    break;
                case 2:
                    if (newFont == Font.None)
                        newFont = Font.Italic;
                    else if (newFont == Font.Bold)
                        newFont = newFont | Font.Italic;
                    else newFont = newFont ^ Font.Italic;
                    break;
                case 3:
                    if (newFont == Font.None)
                        newFont = Font.Underline;
                    else if (newFont == Font.Bold)
                        newFont = newFont | Font.Underline;
                    else if (newFont == Font.Italic)
                        newFont = newFont | Font.Underline;
                    else newFont = newFont ^ Font.Underline;
                    break;
                default:
                    Console.WriteLine("Используйте цифры от 1-3 для выбора нужного редактирования текста!");
                    break;
            }

            return newFont;
        }
        [Flags] enum Font { None=0x0, Bold=0x1, Italic=0x2, Underline=0x4}

        static void Main()
        {
            Font newFont = Font.None;

            ConsoleKeyInfo btn;

            do
            {
                Console.WriteLine("Параметры надписи: {0}\nВарианты ввода: \n\t 1. Bold \n\t 2. Italic \n\t 3. Underline", newFont);
                Console.Write("\nВведите от 1-3 : ");
                bool resA = int.TryParse(Console.ReadLine(), out int N);

                if (resA && N > 0 && N < 4)
                {
                    newFont = getFont(ref newFont, N);
                }
                else
                {
                    Console.WriteLine("ОШИБКА! Используйте цифры от 1-3 для выбора нужного редактирования текста!\n");
                }
                Console.Write("Хотите выйти? нажмите 'Esc'! Далее? Нажмите любую клавишу!\n");
                btn = Console.ReadKey();
                Console.WriteLine();
            }
            while (btn.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }


    }
}
