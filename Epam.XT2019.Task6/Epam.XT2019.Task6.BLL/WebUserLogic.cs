using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using Epam.XT2019.Task6.LogicContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.BLL
{
    public class WebUserLogic : IWebUserLogic
    {
        private SHA512 shaM = new SHA512Managed();
        private IWebUserDao _wuserDao;
        public WebUserLogic(IWebUserDao wuserDao)
        {
            _wuserDao = wuserDao;
        }

        public bool CanLogin(string name, string password)
        {
            var bytePassword = shaM.ComputeHash(Encoding.UTF8.GetBytes(password));
            return _wuserDao.CanLogin(name, bytePassword);
        }

        public bool CreateUser(string name, string password)
        {
            try
            {
                var bytePassword = shaM.ComputeHash(Encoding.UTF8.GetBytes(password));
                WebUser wuser = new WebUser();
                wuser.Name = name;
                wuser.Password = bytePassword;                
                wuser.Role = 0;
                _wuserDao.SaveToFile(wuser);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public bool DeleteUser(int Id)
        {
            try
            {
                _wuserDao.DeleteUser(Id);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public List<WebUser> DisplayUsers()
        {
            List<WebUser> wusers = new List<WebUser>();
            try
            {
                wusers = _wuserDao.GetAll();
            }
            catch (Exception e)
            {
                logIt(e.Message);
            }
            return wusers;
        }

        public bool ToggleAdmin(string wname)
        {
            return _wuserDao.ToggleAdmin(wname);
        }
        private void logIt(string message)
        {
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\log.txt", message + Environment.NewLine);
        }
    }
}
