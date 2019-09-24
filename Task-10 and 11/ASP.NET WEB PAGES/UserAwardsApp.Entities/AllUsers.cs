using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    public class AllUsers
    {
        public List<User> Users { get; set; }

        public AllUsers()
        {
            Users = new List<User>();
        }
    }
}
