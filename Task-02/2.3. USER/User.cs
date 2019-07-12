using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._USER
{
    class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            private set
            {
                if (dateOfBirth < DateTime.Now)
                    dateOfBirth = value;
                else
                    throw new DataMisalignedException("Укажите правильный формат даты! (дд.мм.гггг или дд/мм/гггг");
            }
        }

        public User(string firstName, string lastName, DateTime dateOfBith)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBith;
        }

        public string Name => $"{LastName} {FirstName}";

        //public double Age => ((DateTime.Now - DateOfBirth).Days) / 360;

        //public string Age(DateTime Dob)
        //{
        //    DateTime Now = DateTime.Now;
        //    int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
        //    DateTime PastYearDate = Dob.AddYears(Years);
        //    int Months = 0;
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        if (PastYearDate.AddMonths(i) == Now)
        //        {
        //            Months = i;
        //            break;
        //        }
        //        else if (PastYearDate.AddMonths(i) >= Now)
        //        {
        //            Months = i - 1;
        //            break;
        //        }
        //    }
        //    int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
        //    return string.Format($"{Years}, {Days}, {Months}");
        //}
        public double Age => ((DateTime.Now - DateOfBirth).Days) / 360;

        public override string ToString()
        {
            return $"\nПользователь создан!\n ФИО: {Name}\nРодился: {dateOfBirth:d.M.yyyy}\tВозраст: {Age}";
        }
    }
}
