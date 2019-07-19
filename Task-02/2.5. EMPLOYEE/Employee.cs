using System;
using System.Collections.Generic;
using System.Text;

namespace _2._5._EMPLOYEE
{
    class Employee: User
    {
        public string Position { get; set; }

        private DateTime startWorkDate;
        public DateTime StartWorkDate
        {
            get { return startWorkDate; }
            private set
            {
                if (startWorkDate < DateTime.Now)
                    startWorkDate = value;
                else
                    throw new DataMisalignedException("Укажите правильный формат даты! Дата не может быть больше сегодняшнего дня! (дд.мм.гггг или дд/мм/гггг");
            }
        }
        public Employee(string firstName, string lastName, DateTime dateOfBith, string position, DateTime startWorkDate) :base(firstName, lastName, dateOfBith)
        {
            this.Position = position;
            this.StartWorkDate = startWorkDate;
        }
        public double WorkExperience => ((DateTime.Now - StartWorkDate).Days) / 360;

        public override string ToString()
        {
            return $"\nВ базе новый сотрудник!\nФИО: {Name}\nРодился: {DateOfBirth:d.M.yyyy}\tВозраст: {Age}\nДолжность: {Position}\tСтаж работы: {WorkExperience} лет";
        }
    }
}
