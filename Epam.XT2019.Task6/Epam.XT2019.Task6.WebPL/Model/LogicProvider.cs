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
        static IWebUserLogic wuLogic = DependencyResolver.WULogic;

        public static bool CrtUsr(string name, string dateOfBirth) => uLogic.CreateUser(name, dateOfBirth);
        public static bool DltUsr(string id)
        {
            if (int.TryParse(id, out int numId))
            {
                return uLogic.DeleteUser(numId);
            }
            return false;
        }

        public static List<User> DsplUsrs() => uLogic.DisplayUsers();
        public static bool CrtAwd(string name) => awLogic.CreateAward(name);
        public static List<Award> DsplAwds() => awLogic.DisplayAwards();
        public static List<Award> DsplUsAwds(int id) => awLogic.DisplayUserAwards(id);
        public static bool DltAwd(string id)
        {
            if (int.TryParse(id, out int numId))
            {
                return awLogic.DeleteAward(numId);
            }
            return false;           
        }

        public static bool Rwrd(int userId, int awardId) => awLogic.Reward(userId, awardId);
        

        public static int CrtWUsr(string name, string password) => wuLogic.CreateUser(name, password);
        public static bool DltWUsr(string id)
        {
            if (int.TryParse(id, out int numId))
            {
                return uLogic.DeleteUser(numId);
            }
            return false;
        }
        public static List<WebUser> DsplWUsrs() => wuLogic.DisplayUsers();
        public static bool CanLogin(string name, string password)
        {
            return wuLogic.CanLogin(name, password);
        }
        public static int TglAdmn(int id)
        {
            return wuLogic.ToggleAdmin(id);
        }
        public static bool IsAdmn(string name)
        {
            return wuLogic.IsAdmin(name);
        }

    }
}