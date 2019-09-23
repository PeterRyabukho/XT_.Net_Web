using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    public class Account
    {
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Account(string Login, string Password, string Role)
        {
            ID = Guid.NewGuid();
            this.Login = Login;
            this.Password = Password;
            this.Role = Role;
        }

        //[JsonConverter]
        //public Account(string Login, string Password, string Role, Guid ID)
        //{
        //    this.ID = ID;
        //    this.Login = Login;
        //    this.Password = Password;
        //    this.Role = Role;
        //}
    }
}
