using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DesignPatterns;
using Entities.DesignPatterns;


namespace Pl.DesignPatterns
{
    class Program
    {
        public static Dictionary<int, Guid> UserIDs = new Dictionary<int, Guid>();

        public static Dictionary<int, Guid> AwardIDs = new Dictionary<int, Guid>();

        static void Main(string[] args)
        {
            MainInterface();
        }

        private static void MainInterface()
        {
            Console.WriteLine("\nPlase select some action:");
            Console.WriteLine("1. Add new User");
            Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Show all Users");
            Console.WriteLine("4. Add new Award");
            Console.WriteLine("5. Remove Award");
            Console.WriteLine("6. Show all Awards");
            Console.WriteLine("7. Add Award to User");
            Console.WriteLine("8. Exit");
            Console.Write("Enter: ");
            var numberOfAwardForUser = Console.ReadLine();

            if (uint.TryParse(numberOfAwardForUser, out uint selectedOption)
                && selectedOption > 0
                && selectedOption < 9)
            {
                switch (selectedOption)
                {
                    case 1:
                        //Console.Write("1. Enter user ID: ");
                        //bool IdChecked = int.TryParse(Console.ReadLine(), out int id);


                        Console.Write("\n1. Enter user Name: ");
                        string userName = Console.ReadLine();
                        Console.Write("2. Enter user date of birth: ");
                        bool BDateChecked = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBith);
                        if (BDateChecked && dateOfBith < DateTime.Now)
                        {
                            UserManager.CreateUser(userName, dateOfBith);
                            //User newUserCreated = new User(userName, dateOfBith);
                            //UserManager.AddUser(newUserCreated);
                        }
                        else
                        {
                            Console.WriteLine("\n User not created! You cannot have a date of birth later than the present time!");
                            Console.ReadKey();
                            MainInterface();
                        }
                        Console.WriteLine($"\nUser '{userName}' created!\n");
                        MainInterface();
                        //To DO: BLL - add User
                        break;
                    case 2:
                        Console.WriteLine("\nChoose which user to delete:");
                        ShowAllItems(UserManager.GetAllUsers());
                        Console.Write("\nEnter name of user y whant to remove: ");
                        string userNameToRemove = Console.ReadLine();
                        UserManager.RemoveUser(userNameToRemove);
                        Console.Write($"\nUser {userNameToRemove} removed!\n");
                        ShowAllItems(UserManager.GetAllUsers());
                        Console.WriteLine("Press any button to return to the main menu ");
                        Console.ReadKey();
                        MainInterface();
                        //To DO: BLL - remove User
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        Console.WriteLine("List all users: ");
                        ShowUsersAndAddNumbers();
                        //ShowAllItems(UserManager.GetAllUsers());
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        MainInterface();
                        //To DO: BLL - get all Users
                        //       PL - show all Users
                        break;
                    case 4:
                        Console.Write("\n1. Enter award Name: ");
                        string awardName = Console.ReadLine();
                        AwardManager.CreateAward(awardName);
                        Console.WriteLine($"\nAward '{awardName}' created!\n");
                        MainInterface();
                        //TO DO:BLL - Add Award
                        break;
                    case 5:
                        Console.WriteLine("\nChoose which Award to delete:");
                        ShowAllItems(AwardManager.GetAllAwards());
                        Console.Write("\nEnter name of Award y whant to remove: ");
                        string awardNameToRemove = Console.ReadLine();
                        AwardManager.RemoveAward(awardNameToRemove);
                        Console.Write($"\nAward {awardNameToRemove} removed!\n");
                        ShowAllItems(AwardManager.GetAllAwards());
                        Console.WriteLine("Press any button to return to the main menu ");
                        Console.ReadKey();
                        MainInterface();
                        //TO DO:BLL - Remove Award
                        break;
                    case 6:
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        Console.WriteLine("List all awards: ");
                        ShowAwardsAndAddNumbers();
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        MainInterface();
                        //TO DO:BLL - Get All Awards
                        //      PL - Show All Awards
                        break;
                    case 7:
                        ShowUsersAndAddNumbers();
                        Console.Write("\nEnter the USER number to whom you would like to give an award: ");
                        string numberOfUserForAward = Console.ReadLine();

                        if (!UserIDs.ContainsKey(int.Parse(numberOfUserForAward)))
                        {
                            Console.WriteLine("Invalid User number!");
                            goto case 7;
                        }

                        Guid userID = UserIDs[int.Parse(numberOfUserForAward)];

                        ShowAwardsAndAddNumbers();
                        Console.Write("\nEnter the AWARD number: ");
                        numberOfAwardForUser = Console.ReadLine();
                        if (!AwardIDs.ContainsKey(int.Parse(numberOfAwardForUser)))
                        {
                            Console.WriteLine("Invalid Award number!");
                            return;
                        }

                        Guid awardID = AwardIDs[int.Parse(numberOfAwardForUser)];

                        
                        
                        if (AwardManager.AddAwardToUser(userID, awardID))
                        {
                            Console.WriteLine($@"Award - ""{AwardManager.GetAwardByID(awardID).Name}"" successfully added to User {UserManager.GetUserByID(userID).Name}!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No additions occurred.");
                            Console.ReadKey();
                        }
                        
                        //TO DO:Bll-Add Award to User
                        break;
                    case 8:
                        return;
                }
            }
        }

        private static void ShowAllItems<T>(ICollection<T> users)
        {
            int count = 1;
            foreach (var user in users)
            {
                Console.WriteLine($"{count}. {user.ToString()}");
                //Console.WriteLine($"\n{count}. ID:[{user.ID}] - {user.Name} - {user.DateOfBirth:dd.MM.yyyy} - {user.Age} years old");
                count++;
            }
        }

        public static void ShowUsersAndAddNumbers()
        {
            UserIDs.Clear();
            List<User> allUsers = UserManager.GetAllUsers().ToList();
            int numberOfUser = 1;
            foreach (var item in allUsers)
            {
                UserIDs.Add(numberOfUser, item.ID);
                Console.WriteLine($"\n{numberOfUser}. {item.ToString()}\n");
                numberOfUser++;
            }
        }
        public static void ShowAwardsAndAddNumbers()
        {
            AwardIDs.Clear();
            List<Award> allAwards = AwardManager.GetAllAwards().ToList();
            int numberOfAwards = 1;
            foreach (var item in allAwards)
            {
                AwardIDs.Add(numberOfAwards, item.ID);
                Console.WriteLine($"\n{numberOfAwards}. {item.ToString()}\n");
                numberOfAwards++;
            }
        }
    }
}
