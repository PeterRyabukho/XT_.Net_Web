using DAL.DesignPatterns;
using Entities.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dependencys.DesignPatterns
{
    public static class Dependency
    {
        public static IKeepUsers usersStorage { get; } = new DAL_File_User();
        public static IKeepAwards awardsStorage { get; } = new DAL_File_Award();
    }
}
