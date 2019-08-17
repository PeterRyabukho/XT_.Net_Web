using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Entities.DesignPatterns
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
