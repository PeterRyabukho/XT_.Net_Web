using System;

namespace _2._5._EMPLOYEE
{
    class Program
    {
        static void Main()
        {
            string firstName;
            string lastName;
            string position;
            Console.WriteLine("Вы сотрудник компании? Да/Нет Нажмите соответствующую клавишу 'y'/'n'");
            ConsoleKeyInfo btn = Console.ReadKey();
            if (btn.Key == ConsoleKey.Y)
            {
                Console.Write("\nВведите имя: ");
                firstName = Console.ReadLine();

                Console.Write("Введите фамилию: ");
                lastName = Console.ReadLine();

                Console.Write("Введите дату рождения: ");
                position = IamEmployee(firstName, lastName);
            }
            else
            {

                Console.Write("\nВведите имя: ");
                firstName = Console.ReadLine();

                Console.Write("Введите фамилию: ");
                lastName = Console.ReadLine();

                Console.Write("Введите дату рождения: ");
                bool DoBU = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBithUser);
                if (DoBU)
                {
                    User user = new User(firstName, lastName, dateOfBithUser);
                    Console.WriteLine(user);
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите правельный формат даты!");
                    Main();
                }
            }

            Console.ReadKey();
        }

        private static string IamEmployee(string firstName, string lastName)
        {
            string position="";
            bool DoBE = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBithEmployee);
            if (DoBE)
            {
                Console.Write("Введите должность: ");
                position = Console.ReadLine();

                Console.Write("Введите дату начала работы в компании: ");
                bool SwD = DateTime.TryParse(Console.ReadLine(), out DateTime startWorkDate);
                if (SwD)
                {
                    Employee employee = new Employee(firstName, lastName, dateOfBithEmployee, position, startWorkDate);
                    Console.WriteLine(employee);
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите правельный формат даты!");
                    Main();
                }

            }
            else
            {
                Console.WriteLine("Ошибка! Введите правельный формат даты!");
                Main();
            }

            return position;
        }
    }
}
