using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    public class Award
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public byte[] Image { get; set; }

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

        public Award()
        {

        }

        public Award(string Name, byte[] Image)
        {
            ID = Guid.NewGuid();
            this.Name = Name;
            this.Image = Image;
        }

        public override string ToString()
        {
            return $"ID:[{ID}] - Award: {Name}";
        }
    }

}
