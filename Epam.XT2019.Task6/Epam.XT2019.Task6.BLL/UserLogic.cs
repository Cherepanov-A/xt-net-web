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
        public bool CreateUser(string name, string dateOfBirth)
        {
            try
            {
                User user = new User();                
                user.Name = name;
                user.DateOfBirth = dateOfBirth;
                var tmp = DateTime.Parse(dateOfBirth);
                TimeSpan temp = DateTime.Now - tmp;
                user.Age = (int)temp.TotalDays / 365;                
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
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\log.txt", message + Environment.NewLine);
        }

        public bool DeleteUser(int id)
        {            
            try
            {
               
                _userDao.DeleteUser(id);
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
