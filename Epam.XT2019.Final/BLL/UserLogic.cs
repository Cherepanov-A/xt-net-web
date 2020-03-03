using BLLContracts;
using DAOContracts;
using Entities;
using System;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        //private SHA512 shaM = new SHA512Managed();
        private static IUserDAO _userDao;
        public UserLogic(IUserDAO userDao)
        {
            _userDao = userDao;
        }
        
        public int BuyPhoto(string userName, int photoId, double prise)
        {
            Logger.InitLogger();
            int result = -1;
            User user = _userDao.GetUser(userName);            
            if (user.Accaunt < prise)
            {
                result = 0;
            }
            try
            {
                if (_userDao.BuyPhoto(user.Id, photoId) && _userDao.EditAcc(-prise, user.Id))
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

        public int ChargeAcc(double sum, int id)
        {
            Logger.InitLogger();
            int result = 0;
            try
            {
                if (_userDao.EditAcc(sum, id))
                {
                    result = 1;
                    Logger.Log.Info($"User id = {id}. Accaunt charged");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public int Register(string userName, byte[] password)
        {
            if (_userDao.CheckUserExists(userName))
            {
                return 0;
            }
            Logger.InitLogger();
            int result = 0;
            User user = new User();
            user.Name = userName;
            user.Password = password;
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

        public bool CanLogin(string name, byte[] password)
        {
            bool result = false;
            Logger.InitLogger();
            User user = _userDao.GetUser(name);
            try
            {
                if ((user != null) && (password == user.Password))
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                result = false;
                Logger.Log.Error(e.Message);
            }
            return result;
        }
    }
}
