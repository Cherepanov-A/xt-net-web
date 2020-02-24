using Epam.XT2019.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.LogicContracts
{
    public interface IUserLogic
    {
        bool CreateUser(string name, string dateOfBirth);
        bool DeleteUser(int Id);
        List<User> DisplayUsers();
        
        
    }
}
