using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7._3.EMAIL_FINDER
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailFinder();
        }
        private static void EmailFinder()
        {
            Console.WriteLine("1. Start program and use ready file with various email's!");
            Console.WriteLine("2. Enter e-mail's manually through the console");
            Console.WriteLine("3. Exit");
            Console.Write("Enter: ");
            bool checkInput = int.TryParse(Console.ReadLine(), out int result);
            if (checkInput && result > 0 && result < 4)
            {
                switch (result)
                {
                    case 1:
                        string inputFileWithEmail = ReadMyFaile();
                        Console.WriteLine("\nY'r file with e-mails:\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(inputFileWithEmail);
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Press any button to see all e-mails which match the pattern from the task-7.3: ");
                        Console.ReadLine();

                        Console.WriteLine("\nFound all valid Emails!\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        FindAllValidEmails(inputFileWithEmail);
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                        Console.WriteLine("\nPress any button to continue...");

                        Console.ReadLine();
                        EmailFinder();
                        break;
                    case 2:
                        Console.WriteLine("\nEnter e-mail, that match's patern: the name of the mailbox can contain letters, numbers, a period, a hyphen, and an underscore, with the first and last characters being only letters or numbers. The same rules apply for subdomain names, but the period and underscore are not valid. The top-level domain name can consist only of letters in an amount from 2 to 6.: \n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Enter: ");
                        string inputEmails = Console.ReadLine();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                        Console.WriteLine("\nFound some valid e-mails!\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        FindAllValidEmails(inputEmails);
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                        Console.ReadLine();
                        EmailFinder();
                        break;
                    case 3:
                        return;
                }
            }
            else
            {
                Console.WriteLine("\nWrong input!");
                Console.ReadKey();
                EmailFinder();
            }
        }

        private static void FindAllValidEmails(string inputFileWithEmails)
        {
            Regex tagFinder = new Regex(@"((\b[A-Za-z0-9]+\.?[A-Za-z0-9]+\-?[A-Za-z0-9]+\w?[A-Za-z0-9]+)|(\b[A-Za-z0-9]+\.?[A-Za-z0-9]+\w?[A-Za-z0-9]+\-?[A-Za-z0-9]+)|(\b[A-Za-z0-9]+\w?[A-Za-z0-9]+\.?[A-Za-z0-9]+\-?[A-Za-z0-9]+)|(\b[A-Za-z0-9]+\w?[A-Za-z0-9]+\-?[A-Za-z0-9]+\.?[A-Za-z0-9]+)|(\b[A-Za-z0-9]+\-?[A-Za-z0-9]+\.?[A-Za-z0-9]+\w?[A-Za-z0-9]+)|(\b[A-Za-z0-9]+\-?[A-Za-z0-9]+\w?[A-Za-z0-9]+\.?[A-Za-z0-9]+))\@[A-Za-z0-9]+\-?[A-Za-z0-9]+\.(([A-Za-z0-9]+\-?[A-Za-z0-9]+\.[A-Za-z]{2,6}(\b))|[A-Za-z]{2,6}(\b))");
            var matches = tagFinder.Matches(inputFileWithEmails);

            foreach (Match item in matches)
            {
                    Console.WriteLine(item);
            }
        }

        private static string ReadMyFaile()
        {
            string inputFileWithEmails;
            using (StreamReader streamReader = new StreamReader(@"File With Emails.txt"))
            {
                inputFileWithEmails = streamReader.ReadToEnd();
            }

            return inputFileWithEmails;
        }
   
    }
}
