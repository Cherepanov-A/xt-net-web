using Epam.XT2019.Task6.Ioc;
using Epam.XT2019.Task6.LogicContracts;
using Epam.XT2019.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.XT2019.Task6.WebPL.Model
{
    public class LogicProvider
    {
        static IUserLogic uLogic = DependencyResolver.ULogic;
        static IAwardLogic awLogic = DependencyResolver.ALogic;
        public static bool CrtUsr(string id, string name, string dateOfBirth)
        {
            return uLogic.CreateUser(id, name, dateOfBirth);
        }
        public static bool DltUsr(string id)
        {
            return uLogic.DeleteUser(id);
        }
        public static List<User> DsplUsrs()
        {
            return uLogic.DisplayUsers();
        }
        public static bool CrtAwd(string id, string name)
        { 
            return awLogic.CreateAward(id, name);
        }
        //bool success = uLogic.CreateUser(id, name, dateOfBirth);
    }
}