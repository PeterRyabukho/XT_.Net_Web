using System;

namespace _2._4._MY_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string string1 = Console.ReadLine();

            Console.Write("Введите вторую строку: ");
            string string2 = Console.ReadLine();

            MyString str1 = new MyString(string1);
            MyString str2 = new MyString(string2);
            MyString result = new MyString("");

            Console.WriteLine("\nСравниваем строки: ");
            result.MyCompare(str1, str2);

            Console.WriteLine("\nНаходим индекс буквы в первой строке...");
            Console.Write("Введите букву: ");

            bool t = char.TryParse(Console.ReadLine(), out char cha);
            int index = result.MyIndexOf(str1, cha);
            Console.WriteLine("Индекс - [{0}]",index);

            Console.WriteLine("\nСкладываем две строки: ");
            result=str1.MyConcat(str1, str2);
            result.Print();

            Console.WriteLine("\nВ массив чар и обратно:");
            str1.ToCharArray();
            Console.WriteLine(str1);
 
            Console.ReadLine();
        }
    }
}
