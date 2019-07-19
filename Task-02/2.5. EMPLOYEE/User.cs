using System;
using System.Collections.Generic;
using System.Text;

namespace _2._5._EMPLOYEE
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
                    throw new DataMisalignedException("Укажите правильный формат даты! Дата не может быть больше сегодняшнего дня! (дд.мм.гггг или дд/мм/гггг");
            }
        }

        public User(string firstName, string lastName, DateTime dateOfBith)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBith;
        }

        public string Name => $"{LastName} {FirstName}";

        public double Age => ((DateTime.Now - DateOfBirth).Days) / 360;

        public override string ToString()
        {
            return $"\nПользователь создан!\nФИО: {Name}\nРодился: {DateOfBirth:d.M.yyyy}\tВозраст: {Age} лет(года)";
        }
    }
}

