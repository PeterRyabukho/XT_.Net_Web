using System;

namespace _2._4._MY_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString str1 = new MyString("EFGH");
            MyString str2 = new MyString("ABCD");

            //MyCompare(str1, str2);
            Console.WriteLine(str1>str2);
 
            Console.ReadLine();
        }

        //private static void MyCompare(MyString str1, MyString str2)
        //{
        //    if (1)
        //        Console.WriteLine("Строка str1 перед строкой str2");
        //    else if (str1 < str2)
        //        Console.WriteLine("Строка str2 перед строкой str1");
        //    else
        //        Console.WriteLine("Строки равны");
        //}
    }
}
