using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._USER
{
    class User
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

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

        public string Name => $"{lastName} {firstName}";

        public double Age => ((DateTime.Now - DateOfBirth).Days) / 360;

        public override string ToString()
        {
            return $"\nПользователь создан!\n ФИО: {Name}\nРодился: {dateOfBirth:d.M.yyyy}\tВозраст: {Age}";
        }
    }
}
