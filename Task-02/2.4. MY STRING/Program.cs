using System;

namespace _2._4._MY_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString str1 = new MyString("Hello");
            MyString str2 = new MyString("World");
            MyString result = new MyString("");

            result.MyCompare(str1, str2);

            int index = result.MyIndexOf(str1, 'o');
            Console.WriteLine(index);

            result=str1.MyConcat(str1, str2);
            result.Print();

 
            Console.ReadLine();
        }
    }
}
