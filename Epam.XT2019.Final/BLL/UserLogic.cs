using BLLContracts;
using DAOContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDAO _userDao;
        public UserLogic(IUserDAO userDao)
        {
            _userDao = userDao;
        }
    }
}
