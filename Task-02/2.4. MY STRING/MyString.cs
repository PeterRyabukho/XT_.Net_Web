using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._MY_STRING
{
    class MyString
    {
        private char[] charArr;
        //public string Str1 { get; set; }
        //public char[] CharArr => Str1.ToCharArray();
        public char[] CharArr { get; set; }
        public MyString()
        {

        }

        public MyString(string str)
        {
            //this.charArr = str.ToCharArray();
            this.CharArr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
                CharArr[i] = str[i];
        }

        public static int operator > (MyString str1, MyString str2)
        {
            for (int i = 0; i < str1.CharArr.Length; i++)
            {
                for (int j = 0; j < str2.CharArr.Length; j++)
                {
                    if (str1.CharArr[i] < str2.CharArr[j])
                        return -1;
                }
            }
            return 1;
        }
        public static int operator <(MyString str1, MyString str2)
        {
            for (int i = 0; i < str1.CharArr.Length; i++)
            {
                for (int j = 0; j < str2.CharArr.Length; j++)
                {
                    if (str1.CharArr[i] > str2.CharArr[j])
                        return -1;
                }
            }
            return 1;
        }
    }
}
