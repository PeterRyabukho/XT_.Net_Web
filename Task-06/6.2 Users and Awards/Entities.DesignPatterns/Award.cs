using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Entities.DesignPatterns
{
    public class Award
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public void ChangeAward(string name)
        {
            Name = name;
        }

        [JsonConstructor]
        public Award(string Name, Guid ID)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public Award(string Name)
        {
            ID = Guid.NewGuid();
            this.Name = Name;
        }

        public override string ToString()
        {
            return $"ID:[{ID}] - Award: {Name}";
        }
    }
}
