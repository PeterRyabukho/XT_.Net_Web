using System;
using System.Collections.Generic;

namespace _3._2._WORD_FREQUENCY
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "The upgrade should provide the functionality to set two properties: the number of orders needed to be eligible for the discount, and the percentage of the discount. " +
                "This makes it a perfect scenario for default interface members. You can add a method to the ICustomer interface, and provide the most likely implementation. " +
                "All existing, and any new implementations can use the default implementation, or provide their own";

            string[] arr = str1.ToLower().Split(' ', '.', ',','-') ;

            Dictionary<string, List<int>> myDictionary = new Dictionary<string, List<int>>();
            int count = 1;
            foreach (var word in arr)
            {
                if(!myDictionary.ContainsKey(word))
                {
                    myDictionary.Add(word, new List<int>(count));
                }
                else
                {
                    myDictionary[word].Add(count++);
                }
            }

            Console.WriteLine($"     Слова\t\t\tКол-во повторений в тексте");
            foreach (var word in myDictionary)
            {

                Console.WriteLine($"{word.Key, 10}\t\t\t{word.Value.Count+1}");
            }


            Console.ReadLine();
        }
    }
}
