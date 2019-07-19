using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._MY_STRING
{
    class MyString
    {
        public char[] CharArr { get; set; }

        public char this[int index]
        {
            get => CharArr[index];
            set => CharArr[index] = value;
        }
        public MyString()
        {
            CharArr = new char[0];
        }

        public MyString(string str)
        {
            //this.charArr = str.ToCharArray();
            this.CharArr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
                CharArr[i] = str[i];
        }

        public MyString(char[] array)
        {
            CharArr = array;
        }

        public void Print()
        {
            for (int i = 0; i < CharArr.Length; i++)
            {
                Console.Write(CharArr[i]);
            }
            Console.WriteLine();
        }
        public int Length => CharArr.Length;

        public char[] ToCharArray() => CharArr;

        public override string ToString()
        {
            return new string(CharArr);
        }

        public MyString MyConcat(MyString str1, MyString str2)
        {
            MyString result = new MyString();
            result = str1 + str2;
            return result;
        }

        public void MyCompare(MyString str1, MyString str2)
        {
            if (str1 > str2)
                Console.WriteLine("Строка str1 перед строкой str2");
            else if(str1 < str2)
                Console.WriteLine("Строка str2 перед строкой str1");
            else if (str1==str2)
                Console.WriteLine("Строки равны");
        }

        public int MyIndexOf(MyString str1, char toFound)
        {
            int left = 0;
            int right = str1.CharArr.Length;
            int mid;
            while (!(left >= right))
            {
                mid = (left + right) / 2;
                if (str1.CharArr[mid] == toFound)
                    return mid;
                if (str1.CharArr[mid] > toFound) 
                    right = mid;
                else
                    left = mid + 1; 
            }
            return mid = -1;
        }

        public static MyString operator + (MyString str1, MyString str2)
        {
            MyString newStr = new MyString();
            newStr.CharArr = new char[str1.CharArr.Length + str2.CharArr.Length];
            for (int i = 0; i < str1.CharArr.Length; i++)
            {
                newStr.CharArr[i] = str1.CharArr[i];
            }
            for (int j = 0; j < str2.CharArr.Length; j++)
            {
                newStr.CharArr[j+str1.CharArr.Length] = str2.CharArr[j];
            }


            return newStr;
        }

        public static bool operator >(MyString str1, MyString str2) => str1.Length > str2.Length;

        //public static bool operator > (MyString str1, MyString str2)
        //{
        //    for (int i = 0; i < str1.Length; i++)
        //    {
        //        for (int j = 0; j < str2.Length; j++)
        //        {
        //            if (str1.CharArr[i] < str2.CharArr[j])
        //                return true;
        //        }
        //    }
        //    return false;
        //}

        public static bool operator <(MyString str1, MyString str2) => str1.Length < str2.Length;

        //public static bool operator < (MyString str1, MyString str2)
        //{
        //    for (int i = 0; i < str1.Length; i++)
        //    {
        //        for (int j = 0; j < str2.Length; j++)
        //        {
        //            if (str1.CharArr[i] > str2.CharArr[j])
        //                return true;
        //        }
        //    }
        //    return false;
        //}

        //public static bool operator ==(MyString str1, MyString str2) => str1.Equals(str2);

        public static bool operator ==(MyString str1, MyString str2)
        {
            if (str1.Length == str2.Length)
                return true;
            return false;
        }

        //public static bool operator !=(MyString str1, MyString str2) => str2.Equals(str1);

        public static bool operator !=(MyString str1, MyString str2)
        {
            if (str1.Length != str2.Length)
                return true;
            return false;
        }

        //public static bool operator !=(MyString str1, MyString str2)
        //{
        //    for (int i = 0; i < str1.Length; i++)
        //    {
        //        for (int j = 0; j < str2.Length; j++)
        //        {
        //            if (str1.CharArr[i] != str2.CharArr[j])
        //                return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
