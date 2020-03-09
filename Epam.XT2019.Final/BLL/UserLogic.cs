using BLLContracts;
using DAOContracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        private SHA512 shaM = new SHA512Managed();
        private static IUserDAO _userDao;
        public UserLogic(IUserDAO userDao)
        {
            _userDao = userDao;
        }

        public int BuyPhoto(string userName, int photoId, double prise, string creator)
        {
            Logger.InitLogger();
            int result = -1;
            User user = _userDao.GetUser(userName);
            User photoCreator = _userDao.GetUser(creator);
            if (user.Accaunt < prise)
            {
                result = 0;
            }
            try
            {
                if (_userDao.BuyPhoto(user.Id, photoId) && _userDao.EditAcc((user.Accaunt - prise), user.Id) && _userDao.EditAcc((photoCreator.Accaunt + prise), photoCreator.Id));
                {
                    result = 1;
                    Logger.Log.Info($"User {userName} buyed a photo id = {photoId}");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
            return result;
        }

        public double CheckAcc(string name)
        {
            User user = _userDao.GetUser(name);
            return user.Accaunt;
        }

        public int ChargeAcc(double addition, string name)
        {
            User user = _userDao.GetUser(name);
            double sum = user.Accaunt + addition;
            Logger.InitLogger();
            int result = 0;
            try
            {
                if (_userDao.EditAcc(sum, user.Id))
                {
                    result = 1;
                    Logger.Log.Info($"User id = {user.Id}. Accaunt charged");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public int Register(string userName, string password)
        {
            if (_userDao.CheckUserExists(userName))
            {
                return 0;
            }
            Logger.InitLogger();
            int result = 0;
            User user = new User();
            var bytePassword = shaM.ComputeHash(Encoding.UTF8.GetBytes(password));
            user.Name = userName;
            user.Password = bytePassword;
            user.Role = false;
            user.Accaunt = 0;
            try
            {
                if (_userDao.SaveUser(user))
                {
                    result = 1;
                    Logger.Log.Info($"User {user.Name} saved");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public bool IsAdmin(string name)
        {
            var user = _userDao.GetUser(name);
            return _userDao.GetRole(user.Id);
        }

        public int SetRole(int id, bool admin)
        {
            int result = 0;
            Logger.InitLogger();
            try
            {
                if (_userDao.SetRole(id, admin))
                {
                    result = 1;
                    Logger.Log.Info($"User id = {id}, admin = {admin}");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public int DeleteUser(int id)
        {
            int result = 0;
            Logger.InitLogger();
            try
            {
                if (_userDao.DeleteUser(id))
                {
                    result = 1;
                    Logger.Log.Info($"User id = {id} was deleted");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public bool CanLogin(string name, string password)
        {
            bool result = false;
            Logger.InitLogger();
            User user = _userDao.GetUser(name);
            var bytePassword = shaM.ComputeHash(Encoding.UTF8.GetBytes(password));
            try
            {
                result = bytePassword.SequenceEqual(user.Password);
            }
            catch (Exception e)
            {
                result = false;
                Logger.Log.Error(e.Message);
            }
            return result;
        }
        public User GetUser(string name)
        {
            User user = new User();
            Logger.InitLogger();
            try
            {
                user = _userDao.GetUser(name);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            Logger.InitLogger();
            try
            {
                users = _userDao.GetUsers();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
            return users;
        }
       
    }
}
