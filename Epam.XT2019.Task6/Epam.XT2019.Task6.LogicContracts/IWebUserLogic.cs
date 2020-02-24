using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT2019.Task6.Entities;

namespace Epam.XT2019.Task6.LogicContracts
{
    public interface IWebUserLogic
    {
        bool CreateUser(string name, string password);
        bool DeleteUser(int Id);
        List<WebUser> DisplayUsers();
        bool ToggleAdmin(string wname);
        bool CanLogin(string name, string password);
    }
}
