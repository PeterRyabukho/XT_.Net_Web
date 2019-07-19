using System;

namespace _2._3._USER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Чтобы создать нового пользователя\nВведите имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            CheckData(firstName, lastName);

            Console.ReadLine();
        }

        private static void CheckData(string firstName, string lastName)
        {
            bool D = DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBith);
            if (D)
            {
                User user1 = new User(firstName, lastName, dateOfBith);
                Console.WriteLine(user1);
            }
            else
            {
                Console.WriteLine("\nОшибка! Введите правельный формат даты!\n");
                Console.Write("Введите дату рождения: ");
                CheckData(firstName, lastName);
            }
        }
    }
}
