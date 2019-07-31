using System;
using System.Collections.Generic;
using System.Text;

namespace _4._5._TO_INT_OR_NOT_TO_INT
{
    public static class IntOrNotExtension
    {
        public static bool IsInThisStringNumberPositive(this string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if(!char.IsDigit(str[i]))
                {
                    return false;
                }
            }

            if(str.StartsWith('-'))
            {
                return false;
            }
            return true;
        }
    }
}
