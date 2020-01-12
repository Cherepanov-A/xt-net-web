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
            try
            {
                User user = new User();
                user.Id = id;
                user.Name = name;
                user.DateOfBirth = DateTime.Parse(dateOfBirth);
                TimeSpan temp = DateTime.Now - user.DateOfBirth;
                user.Age = (int)temp.TotalDays / 365;
                List<User> users = _userDao.GetAll();
                users.Add(user);
                _userDao.SaveToFile(users);
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

        public bool DeleteUser(string id)
        {
            var users = _userDao.GetAll();
            try
            {
                if (users.Count > 0)
                {
                    var otherUsers = users.Where(t => t.Id != id);
                    List<User> redusedUsers = otherUsers.ToList<User>();
                    _userDao.SaveToFile(redusedUsers);
                }
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

        //public List<User> DisplayAwardUsers(string awardId)
        //{
        //    IEnumerable<string> result = 
        //}
    }
}
