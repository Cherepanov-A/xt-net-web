using System;
using Epam.XT2019.Task6.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.DalContracts
{
    public interface IWebUserDao
    {
        bool SaveToFile(WebUser webUser);
        void DeleteUser(int id);
        List<WebUser> GetAll();
        int ToggleAdmin(int id);
        bool CanLogin(string name, byte[] password);
        bool IsAdmin(string name);
    }
}
