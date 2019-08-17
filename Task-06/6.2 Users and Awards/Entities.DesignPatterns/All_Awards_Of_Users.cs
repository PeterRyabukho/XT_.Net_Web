using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Entities.DesignPatterns
{
    [JsonArray]
    public class All_Awards_Of_Users
    {
        public List<AwardsOfUsers> AwardsOfUsers { get; set; }

        public All_Awards_Of_Users()
        {
            AwardsOfUsers = new List<AwardsOfUsers>();
        }
    }
}
