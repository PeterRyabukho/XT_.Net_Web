using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (dateOfBirth < DateTime.Now)
                    dateOfBirth = value;
                else
                    throw new DataMisalignedException("You cannot have a date of birth later than the present time!");
            }
        }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        [JsonConstructor]
        public User(string Name, DateTime DateOfBirth, Guid ID)
        {
            this.ID = ID;
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
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
