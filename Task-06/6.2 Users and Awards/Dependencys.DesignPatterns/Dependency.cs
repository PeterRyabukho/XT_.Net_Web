using DAL.DesignPatterns;
using Entities.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dependencys.DesignPatterns
{
    public static class Dependency
    {
        public static IKeepUsers usersMemoryStorage { get; set; }
        public static IKeepUsers usersFileStorage { get; set; }
        public static IKeepAwards awardsMemoryStorage { get; set; }
        public static IKeepAwards awardsFileStorage { get; set; }

        static Dependency()
        {
            usersMemoryStorage = new DAL_Memory_User();
            awardsMemoryStorage = new DAL_Memory_Award();
            usersFileStorage = new DAL_File_User();
            awardsFileStorage = new DAL_File_Award();
        }
    }
}
