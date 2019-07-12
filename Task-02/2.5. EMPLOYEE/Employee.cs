using System;
using System.Collections.Generic;
using System.Text;

namespace _2._5._EMPLOYEE
{
    class Employee: User
    {
        public string Position { get; set; }
        public DateTime StartWorkDate { get; private set; }
        public Employee(string firstName, string lastName, DateTime dateOfBith, string position, DateTime startWorkDate) :base(firstName, lastName, dateOfBith)
        {
            this.Position = position;
            this.StartWorkDate = startWorkDate;
        }
        public double WorkExperience => ((DateTime.Now - StartWorkDate).Days) / 360;

        public override string ToString()
        {
            return $"\nВ базе новый сотрудник!\nФИО: {Name}\nРодился: {DateOfBirth:d.M.yyyy}\tВозраст: {Age}\nДолжность: {Position}\tСтаж работы: {WorkExperience:d.m.yyyy}";
        }
    }
}
