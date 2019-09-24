using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    [JsonArray]
    public class AllAwardsOfUsers
    {
        public List<AwardsOfUsers> AwardsOfUsers { get; set; }

        public AllAwardsOfUsers()
        {
            AwardsOfUsers = new List<AwardsOfUsers>();
        }
    }
}
