using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7._1.DATE_EXISTANCE
{
    class Program
    {
        static void Main(string[] args)
        {
            DateChecker();

        }

        private static void DateChecker()
        {
            Console.WriteLine("1. Start program");
            Console.WriteLine("2. Exit");

            bool checkInput = int.TryParse(Console.ReadLine(), out int result);
            if (checkInput && result > 0 && result < 3)
            {
                switch (result)
                {
                    case 1:
                        Console.Write($@"Enter text containing the date in the format ""dd-mm-yyyy"": ");
                        string textInput = Console.ReadLine();
                        Regex findDate = new Regex(@"\b([0-1][0-9]|[3][0-1])-([0][0-9]|[1][0-2])-[0-2][0-9][0-9][0-9]\b");
                        var matches = findDate.Matches(textInput);

                        Console.WriteLine($"\nText: '{textInput}' contains date:\n");
                        ShowDateMatches(matches);
                        Console.ReadLine();
                        DateChecker();
                        break;
                    case 2:
                        return;
                }
            }
            else
            {
                Console.WriteLine("\nWrong input!");
                Console.ReadKey();
                DateChecker();
            }
        }

        private static bool ShowDateMatches(MatchCollection matches)
        {
            if (matches.Count != 0)
            {
                foreach (Match item in matches)
                {
                    Console.WriteLine(item);
                }
                return true;
            }
            return false;
        }
    }
}
