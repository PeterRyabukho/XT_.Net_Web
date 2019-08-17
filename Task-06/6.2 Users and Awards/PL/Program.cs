using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.DesignPatterns;
using Entities.DesignPatterns;


namespace Pl.DesignPatterns
{
    class Program
    {
        //private static string createDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";

        public static Dictionary<int, Guid> UserIDs = new Dictionary<int, Guid>();

        public static Dictionary<int, Guid> AwardIDs = new Dictionary<int, Guid>();

        static void Main(string[] args)
        {

            if(MyDirectory.CheckOrCreateDirectoryAndFiles())
                Console.WriteLine($"Directory created, path: {MyDirectory.CreateDirectory}");
            else
                Console.WriteLine($"\nYou can find all files in directory, path: {MyDirectory.CreateDirectory}");

            Thread.Sleep(500);

            if (!UserManager.DeSerializerJsonUsers())
                Console.WriteLine(@"File ""User.txt"" is empty! DEserialization dont complite!");
            else
                Console.WriteLine("\nUSER DEserialization complite!");
            if (!AwardManager.DeSerializerJsonAwards())
                Console.WriteLine(@"File ""Awards.txt"" is empty! DEserialization dont complite!");
            else
                Console.WriteLine("AWARDS DEserialization complite!");
            if (!AwardManager.DeSerializerJsonAwardsOfUsers())
                Console.WriteLine(@"File ""Awards of Users.txt"" is empty! DEserialization dont complite!");
            else
                Console.WriteLine("AWARDS OF USERS DEserialization complite!\n");
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();

            MainInterface();

            if (!UserManager.SerializerJsonUsers())
                Console.WriteLine(@"File ""User.txt"" is empty! Serialization dont complite!");
            else
                Console.WriteLine("\nUSER Serialization complite!");
            if (!AwardManager.SerializerJsonAwards())
                Console.WriteLine(@"File ""Awards.txt"" is empty! Serialization dont complite!");
            else
                Console.WriteLine("AWARDS Serialization complite!");
            if (!AwardManager.SerializerJsonAwardsOfUsers())
                Console.WriteLine(@"File ""Awards of Users.txt"" is empty! Serialization dont complite!");
            else
                Console.WriteLine("AWARDS OF USERS Serialization complite!");
            Console.ReadKey();
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
            Console.WriteLine("8. Show User Awards");
            Console.WriteLine("9. Show all users and their rewards");
            Console.WriteLine("10. Exit");
            Console.WriteLine("11. Serialize Awards");
            Console.WriteLine("12. DE Serialize Awards");
            Console.WriteLine("13. Serialize Awards of Users");
            Console.WriteLine("14. DE Serialize Awards of Users");
            Console.WriteLine("15. Serialize Users");
            Console.WriteLine("16. DE Serialize Users");
            Console.WriteLine("17. Show Awards of Users");
            Console.Write("Enter: ");
            var menuSelection = Console.ReadLine();

            if (uint.TryParse(menuSelection, out uint selectedOption)
                && selectedOption > 0
                && selectedOption < 20)
            {
                switch (selectedOption)
                {
                    case 1:
                        Console.Write("\n1. Enter user Name: ");
                        string userName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userName))
                        {
                            Console.WriteLine("\n Name cannot be empty!\n");
                            Console.ReadKey();
                            goto case 1;
                        }
                        Console.Write("2. Enter user date of birth by pattern dd.mm.yyyy: ");
                        bool BDateChecked = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBith);
                        if (BDateChecked && dateOfBith < DateTime.Now)
                        {
                            UserManager.CreateUser(userName, dateOfBith);
                            Console.WriteLine($"\nUser '{userName}' created!\n");
                            MainInterface();
                        }
                        else
                        {
                            Console.WriteLine("\n User not created! You cannot have a date of birth later than the present time!");
                            Console.ReadKey();
                            goto case 1;
                        }
                        //To DO: BLL - add User
                        break;
                    case 2:
                        Console.WriteLine("\nChoose which User to delete:");
                        ShowUsersAndAddNumbers();
                        Console.Write("\nEnter number of User y whant to remove: ");
                        string numberOfUserToRemove = Console.ReadLine();

                        if(string.IsNullOrWhiteSpace(numberOfUserToRemove))
                        {
                            Console.WriteLine("\nThis field cannot be empty!");
                            Console.ReadKey();
                            goto case 2;
                        }
                        if (!UserIDs.ContainsKey(int.Parse(numberOfUserToRemove)))
                        {
                            Console.WriteLine("\nWrong number of User!");
                            Console.ReadKey();
                            goto case 2;
                        }

                        Guid userGuid = UserIDs[int.Parse(numberOfUserToRemove)];
                        User userToRemove = UserManager.GetUserByID(userGuid);

                        if (UserManager.RemoveUser(userToRemove))
                        {
                            Console.WriteLine($"\nUser {userToRemove} removed!\n");
                            Console.WriteLine("Users: ");
                            ShowAllItems(UserManager.GetAllUsers());
                            Console.ReadKey();
                            MainInterface();
                        }
                        else
                        {
                            Console.WriteLine("\nUser deletion failed!\n");
                            Console.WriteLine("\nPress any button to return to the main menu...\n");
                            Console.ReadKey();
                            MainInterface();
                        }
                        //To DO: BLL - remove User
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        Console.WriteLine("List all users: ");
                        if (!ShowUsersAndAddNumbers())
                        {
                            Console.WriteLine("No Users! Add some new User in main menu!");
                        }
                        else ShowUsersAndAddNumbers();
                        //ShowAllItems(UserManager.GetAllUsers());
                        Console.WriteLine("--------------------------------------------------------------------------------");
                        MainInterface();
                        //To DO: BLL - get all Users
                        //       PL - show all Users
                        break;
                    case 4:
                        Console.Write("\nEnter award Name: ");
                        string awardName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(awardName))
                        {
                            Console.WriteLine("\n Name cannot be empty!\n");
                            Console.ReadKey();
                            goto case 4;
                        }
                        if (!AwardManager.AddAward(awardName))
                        {
                            Console.WriteLine("\nYou cannot create another award with the same name!\n");
                            Console.ReadKey();
                        }
                        else
                            Console.WriteLine($"\nAward '{awardName}' created!\n");
                        MainInterface();
                        //TO DO:BLL - Add Award
                        break;
                    case 5:
                        Console.WriteLine("\nChoose which Award to delete:");
                        ShowAwardsAndAddNumbers();
                        Console.Write("\nEnter number of Award y whant to remove: ");
                        string numberOfAwardToRemove = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(numberOfAwardToRemove))
                        {
                            Console.WriteLine("\nThis field cannot be empty!");
                            Console.ReadKey();
                            goto case 5;
                        }
                        if (!AwardIDs.ContainsKey(int.Parse(numberOfAwardToRemove)))
                        {
                            Console.WriteLine("Wrong number of User!");
                            Console.ReadKey();
                            goto case 5;
                        }

                        Guid awardGuid = AwardIDs[int.Parse(numberOfAwardToRemove)];
                        Award awardToRemove = AwardManager.GetAwardByID(awardGuid);

                        if (AwardManager.RemoveAward(awardToRemove))
                        {
                            Console.WriteLine($"\nAward {awardToRemove} removed!\n");
                            Console.WriteLine("Awards: ");
                            ShowAllItems(AwardManager.GetAllAwards());
                            Console.ReadKey();
                            MainInterface();
                        }
                        else
                        {
                            Console.WriteLine("\nAward deletion failed!\n");
                            Console.WriteLine("\nPress any button to return to the main menu...\n");
                            Console.ReadKey();
                            MainInterface();
                        }
                        //TO DO:BLL - Remove Award
                        break;
                    case 6:
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        Console.WriteLine("List all awards: ");
                        if (!ShowAwardsAndAddNumbers())
                            Console.WriteLine("No Awards! Add some new Award in main menu!");
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        MainInterface();
                        //TO DO:BLL - Get All Awards
                        //      PL - Show All Awards
                        break;
                    case 7:
                        ShowUsersAndAddNumbers();
                        Console.Write("\nEnter the USER number to whom you would like to give an award: ");
                        string numberOfUserForAward = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(numberOfUserForAward))
                        {
                            Console.WriteLine("\nThis field cannot be empty!");
                            Console.ReadKey();
                            goto case 7;
                        }
                        if (!UserIDs.ContainsKey(int.Parse(numberOfUserForAward)))
                        {
                            Console.WriteLine("Invalid User number!");
                            goto case 7;
                        }

                        Guid userID = UserIDs[int.Parse(numberOfUserForAward)];

                        ShowAwardsAndAddNumbers();
                        Console.Write("\nEnter the AWARD number: ");
                        string numberOfAwardForUser = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(numberOfAwardForUser))
                        {
                            Console.WriteLine("\nThis field cannot be empty!");
                            Console.ReadKey();
                            goto case 7;
                        }
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
                            Console.WriteLine("\nYou cannot revard USER the same AWARD multiple times!");
                            Console.ReadKey();
                            Console.Write("\nWant to return to the main menu? y/n ");
                            ConsoleKeyInfo btn = Console.ReadKey();
                            if(btn.Key == ConsoleKey.Y)
                                MainInterface();
                            goto case 7;
                        }
                        MainInterface();
                        //TO DO:Bll,PL - Add Award to User
                        break;
                    case 8:
                        ShowUsersAndAddNumbers();
                        Console.WriteLine("Enter the number of the USER you would like to view awards: ");
                        string numberOfUserToShowAwards = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(numberOfUserToShowAwards))
                        {
                            Console.WriteLine("\nThis field cannot be empty!");
                            Console.ReadKey();
                            goto case 8;
                        }
                        if (!UserIDs.ContainsKey(int.Parse(numberOfUserToShowAwards)))
                        {
                            Console.WriteLine("Invalid User number!");
                            goto case 8;
                        }

                        Guid userToFindByID = UserIDs[int.Parse(numberOfUserToShowAwards)];
                        User newUserForAward = UserManager.GetUserByID(userToFindByID);
                        Award[] userAwards = AwardManager.GetUserAwards(newUserForAward);
                        Thread.Sleep(50);
                        if (userAwards.Length == 0)
                        {
                            Console.WriteLine(newUserForAward.ToString());
                            Console.WriteLine($"Sorry...This user {newUserForAward.Name} has no awards yet...");
                        }
                        else
                        {
                            Console.WriteLine($"\nUser number {numberOfUserToShowAwards}:\n{newUserForAward.ToString()}\n");
                            Console.WriteLine($"Has Awards :");
                            ShowAllItems(userAwards);
                        }
                        //ToDo: Get User Awards - BLL,PL
                        MainInterface();
                        break;
                    case 9:
                        //ToDO: Show All Users Awards-BLL
                        if (!ShowAllUsersAwards())
                            Console.WriteLine("No Users! Add some new User in main menu!");
                        Console.ReadKey();
                        MainInterface();
                        break;
                    case 10:
                        return;
                    case 11:
                        //if (!AwardManager.SerializerJsonAwards())
                        //{
                        //    Console.WriteLine("\nNo Awards added!\n");
                        //    Console.ReadKey();
                        //}
                        //else
                        AwardManager.SerializerJsonAwards();
                        MainInterface();
                        break;
                    case 12:
                        AwardManager.DeSerializerJsonAwards();
                        MainInterface();
                        break;
                    case 13:
                        AwardManager.SerializerJsonAwardsOfUsers();
                        MainInterface();
                        break;
                    case 14:
                        AwardManager.DeSerializerJsonAwardsOfUsers();
                        MainInterface();
                        break;
                    case 15:
                        UserManager.SerializerJsonUsers();
                        MainInterface();
                        break;
                    case 16:
                        UserManager.DeSerializerJsonUsers();
                        MainInterface();
                        break;
                    case 17:
                        AwardManager.ShowCollectionAwardsOfUsers();
                        Console.ReadKey();
                        MainInterface();
                        break;
                }
            }
        }

        private static bool ShowAllUsersAwards()
        {
            int count = 1;
            //User[] users = UserManager.GetAllUsers();
            foreach (var user in UserManager.GetAllUsers())
            {
                if (UserManager.GetAllUsers().Length == 0)
                {
                    return false;
                }
                Console.WriteLine($"{count}. {user.ToString()}\nHave Awards:");
                foreach (var award in AwardManager.GetUserAwards(user))
                {
                    if (award == null)
                    {
                        Console.WriteLine($"Sorry...This user {user.Name} has no awards yet...");
                    }
                    else
                    {
                        Console.WriteLine($@"            ""{award.Name.ToString()}""");
                    }
                }
                count++;
            }
            return true;
        }

        private static void ShowAllItems<T>(ICollection<T> items)
        {
            int count = 1;
            foreach (var item in items)
            {
                Console.WriteLine($"{count}. {item.ToString()}");
                //Console.WriteLine($"\n{count}. ID:[{user.ID}] - {user.Name} - {user.DateOfBirth:dd.MM.yyyy} - {user.Age} years old");
                count++;
            }
        }

        public static bool ShowUsersAndAddNumbers()
        {
            UserIDs.Clear();
            List<User> allUsers = UserManager.GetAllUsers().ToList();
            if (allUsers.Count == 0)
                return false;
            int numberOfUser = 1;
            foreach (var item in allUsers)
            {
                UserIDs.Add(numberOfUser, item.ID);
                Console.WriteLine($"\n{numberOfUser}. {item.ToString()}");
                numberOfUser++;
            }
            return true;
        }
        public static bool ShowAwardsAndAddNumbers()
        {
            AwardIDs.Clear();
            List<Award> allAwards = AwardManager.GetAllAwards().ToList();
            if (allAwards.Count == 0)
                return false;
            int numberOfAwards = 1;
            foreach (var item in allAwards)
            {
                AwardIDs.Add(numberOfAwards, item.ID);
                Console.WriteLine($"\n{numberOfAwards}. {item.ToString()}");
                numberOfAwards++;
            }
            return true;
        }
        //private static bool CheckOrCreateDirectoryAndFiles()
        //{ 
        //    string pathToUsersFile  = $"{createDirectory}Users.txt";
        //    string pathToAwardsFile = $"{createDirectory}Awards.txt";
        //    if (!Directory.Exists(createDirectory))
        //    {
        //        Directory.CreateDirectory(createDirectory);
        //        return true;
        //    }
        //    if (!File.Exists(pathToUsersFile))
        //    {
        //        File.Create(pathToUsersFile);
        //        return true;
        //    }
        //    if (!File.Exists(pathToAwardsFile))
        //    {
        //        File.Create(pathToAwardsFile);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
