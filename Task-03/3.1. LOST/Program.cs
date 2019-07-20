using System;
using System.Collections.Generic;

namespace _3._1._LOST
{
    class Program
    {
        static void Main()
        {
            int[] people = CreateCirclOfPeople();

            if (people == null)
            {
                throw new NullReferenceException("Введено некотректно значение N массив не был создан!");
            }
            
            Queue<int> peopleInCercl = new Queue<int>(people);

            LostGame(peopleInCercl);
            Console.WriteLine($"\n\nПобедитель: человек под номером [{peopleInCercl.Peek()}] !");

            Console.ReadLine();
        }

        private static int[] CreateCirclOfPeople()
        {
            Console.Write("Введите количество человек в кругу: ");
            bool check = int.TryParse(Console.ReadLine(), out int N);

            if (check && N > 1)
            {
                int[] people = new int[N];
                for (int i = 0; i <= people.Length - 1; i++)
                {
                    people[i] = i + 1;
                }

                Console.Write("\nСформирован круг из людей под номерами: ");
                for (int i = 0; i < people.Length; i++)
                {
                    Console.Write(people[i] + " ");
                }
                Console.WriteLine();
                return people;
            }
            else
            {
                Console.WriteLine("\nОшибка! Количество человек должно быть целое число и большее 1 !!!\n");
                Main();
                return null;
            }
        }

        private static void LostGame(Queue<int> peopleInCercl)
        {
            int countLoops = 1;
            while (peopleInCercl.Count != 1)
            {
                Console.Write($"\nОсталось человеков после {countLoops} круга уничтожения под номерами: ");
                peopleInCercl.Enqueue(peopleInCercl.Dequeue());
                peopleInCercl.Dequeue();
                int[] arr = peopleInCercl.ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                countLoops++;
            }
        }
    }
}
