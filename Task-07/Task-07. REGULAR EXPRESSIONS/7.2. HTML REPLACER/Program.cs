using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _7._2.HTML_REPLACER
{
    class Program
    {
        static void Main(string[] args)
        {
            TagsReplacer();
        }

        private static void TagsReplacer()
        {
            Console.WriteLine("1. Start program");
            Console.WriteLine("2. Exit");

            bool checkInput = int.TryParse(Console.ReadLine(), out int result);
            if (checkInput && result > 0 && result < 3)
            {
                switch (result)
                {
                    case 1:
                        string inputHtmlFile = string.Empty;
                        inputHtmlFile = ReadMyFaile();
                        Console.WriteLine("\nY'r HTML file:\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(inputHtmlFile);
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("\nPress any button to replace all tags!");
                        Console.ReadLine();

                        Regex tagFinder = new Regex(@"<.+?>");
                        var matches = tagFinder.Matches(inputHtmlFile);

                        foreach (Match item in matches)
                        {
                            inputHtmlFile = inputHtmlFile.Replace(item.ToString(), "_");
                        }

                        using (StreamWriter streamWriter = new StreamWriter(@"D:\GitApp\XT_.Net_Web\Task-07\Task-07. REGULAR EXPRESSIONS\7.2. HTML REPLACER\HTML file with tags.html"))
                        {
                            streamWriter.Write(inputHtmlFile);
                        }

                        Console.WriteLine("\nSuccessfully! Tags replaced by underscore!\n");

                        string replacedHtmlFile = ReadMyFaile();
                        Console.WriteLine("\nY'r Replaced file!\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(replacedHtmlFile);
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("\nPress any button to continue...");

                        Console.ReadLine();
                        TagsReplacer();
                        break;
                    case 2:
                        return;
                }
            }
            else
            {
                Console.WriteLine("\nWrong input!");
                Console.ReadKey();
                TagsReplacer();
            }
        }

        private static string ReadMyFaile()
        {
            string inputHtmlFile;
            using (StreamReader streamReader = new StreamReader(@"D:\GitApp\XT_.Net_Web\Task-07\Task-07. REGULAR EXPRESSIONS\7.2. HTML REPLACER\HTML file with tags.html"))
            {
                inputHtmlFile = streamReader.ReadToEnd();
            }

            return inputHtmlFile;
        }
    }
}
