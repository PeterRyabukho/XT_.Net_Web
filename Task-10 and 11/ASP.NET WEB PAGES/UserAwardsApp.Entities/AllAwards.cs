using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    [JsonArray]
    public class AllAwards
    {
        public List<Award> Awards { get; set; }

        public AllAwards()
        {
            Awards = new List<Award>();
        }
    }
}
