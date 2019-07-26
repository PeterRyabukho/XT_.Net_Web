using System;
using System.Collections.Generic;

namespace _3._1._LOST
{
    class Program
    {
        static void Main()
        {
            int[] people = CreateCirclOfPeople();
            Queue<int> peopleInCercl = new Queue<int>(people);

            LostGame(peopleInCercl);
            Console.WriteLine($"\n\nAnd the winneeer isss: person [{peopleInCercl.Peek()}] !");

            Console.ReadLine();
        }

        private static int[] CreateCirclOfPeople()
        {
            Console.Write("Enter number of people in the circle: ");
            bool check = int.TryParse(Console.ReadLine(), out int N);

            if (check && N > 1)
            {
                int[] people = new int[N];
                for (int i = 0; i <= people.Length - 1; i++)
                {
                    people[i] = i + 1;
                }

                Console.Write("\nFormed circle of people, under the numbers: ");
                for (int i = 0; i < people.Length; i++)
                {
                    Console.Write(people[i] + " ");
                }
                Console.WriteLine();
                return people;
            }
            else
            {
                Console.WriteLine("\nExapcion! The number of people must be an integer and greater than 1 !!!\n");
                return CreateCirclOfPeople();
            }
        }

        private static void LostGame(Queue<int> peopleInCercl)
        {
            int countLoops = 1;
            while (peopleInCercl.Count != 1)
            {
                Console.Write($"\nPeople left after: {countLoops} circle of destruction, under numbers: ");
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
