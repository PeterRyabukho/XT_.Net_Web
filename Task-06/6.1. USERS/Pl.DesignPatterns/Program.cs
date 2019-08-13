using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DesignPatterns;
using BLL.DesignPatterns;

namespace Pl.DesignPatterns
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MainInterface();
        }

        private static void MainInterface()
        {
            Console.WriteLine("\nPlase select some action:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Show Users");
            Console.WriteLine("4. Exit");
            Console.Write("Enter: ");
            var input = Console.ReadLine();

            if (uint.TryParse(input, out uint selectedOption)
                && selectedOption > 0
                && selectedOption < 5)
            {
                switch (selectedOption)
                {
                    case 1:
                        //Console.Write("1. Enter user ID: ");
                        //bool IdChecked = int.TryParse(Console.ReadLine(), out int id);


                        Console.Write("\n1. Enetr user Name: ");
                        string userName = Console.ReadLine();
                        Console.Write("2. Enter user date of birth: ");
                        bool BDateChecked = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBith);
                        if (BDateChecked)
                        {
                            UserManager.CreateUser(userName, dateOfBith);
                            //User newUserCreated = new User(userName, dateOfBith);
                            //UserManager.AddUser(newUserCreated);
                        }
                        Console.WriteLine("\nUser created!\n");
                        MainInterface();
                        //To DO: BLL - add User
                        break;
                    case 2:
                        Console.WriteLine("\nChoose which user to delete:");
                        ShowAllUsers(UserManager.GetAllUsers());
                        Console.Write("\nEnter name of user y whant to remove: ");
                        string userNameToRemove = Console.ReadLine();
                        UserManager.RemoveUser(userNameToRemove);
                        Console.Write($"\nUser {userNameToRemove} removed!\n");
                        ShowAllUsers(UserManager.GetAllUsers());
                        Console.WriteLine("Press any button to return to the main menu ");
                        Console.ReadKey();
                        MainInterface();
                        //To DO: BLL - remove User
                        break;
                    case 3:
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine("List all users: ");
                        ShowAllUsers(UserManager.GetAllUsers());
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        MainInterface();
                        //To DO: BLL - get all Users
                        //       PL - show all Users
                        break;
                    case 4:
                        return;
                }
            }
        }

        private static void ShowAllUsers(ICollection<User> users)
        {
            int count = 1;
            foreach (var user in users)
            {
                Console.WriteLine($"\n{count}. ID:[{user.ID}] - {user.Name} - {user.DateOfBirth:dd.MM.yyyy} - {user.Age} years old");
                count++;
            }
        }
    }
}
