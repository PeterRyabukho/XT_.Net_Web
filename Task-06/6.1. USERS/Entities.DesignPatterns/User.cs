using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public class User
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public void ChangeUser(string name, DateTime dateOfBirth)
        {
            //ID = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public User(string Name, DateTime DateOfBirth)
        {
            ID = Guid.NewGuid();
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
        }

        public override string ToString()
        {
            return $"ID:[{ID}] - {Name} - {DateOfBirth:dd.MM.yyyy} - {Age} years old";
        }
    }
}
