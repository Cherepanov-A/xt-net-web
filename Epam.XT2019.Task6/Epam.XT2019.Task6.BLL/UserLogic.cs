using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using Epam.XT2019.Task6.LogicContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public bool CreateUser(string id, string name, string dateOfBirth)
        {
            User user = new User();
            user.Id = id;
            user.Name = name;
            user.DateOfBirth = DateTime.Parse(dateOfBirth);
            TimeSpan temp = DateTime.Now - user.DateOfBirth;
            user.Age = (int)temp.TotalDays / 365;
            try
            {
                _userDao.SaveToFile(user);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        private void logIt(string message)
        {
            //File.Open(Directory.GetCurrentDirectory() + "\\log.txt", FileMode.OpenOrCreate);
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\log.txt", message + "\n");
        }

        public bool DeleteUser(string id)
        {
            try
            {
                _userDao.DeleteFromFile(id);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public List<User> DisplayUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = _userDao.GetAll();                
            }
            catch (Exception e)
            {
                logIt(e.Message);
            }
            return users;
        }
    }
}
