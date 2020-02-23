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
        public static bool CrtUsr(string name, string dateOfBirth) => uLogic.CreateUser(name, dateOfBirth);
        public static bool DltUsr(int id) => uLogic.DeleteUser(id);
        public static List<User> DsplUsrs() => uLogic.DisplayUsers();
        public static bool CrtAwd(string id, string name) => awLogic.CreateAward(name);
        //bool success = uLogic.CreateUser(id, name, dateOfBirth);
    }
}