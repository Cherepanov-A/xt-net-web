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
        void SaveToFile(WebUser webUser);
        void DeleteUser(int id);
        List<WebUser> GetAll();
        bool ToggleAdmin(string wname);
        bool CanLogin(string name, byte[] password);
    }
}
