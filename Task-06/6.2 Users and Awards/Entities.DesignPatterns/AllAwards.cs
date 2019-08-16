using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Entities.DesignPatterns
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
