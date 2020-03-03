using BLLContracts;
using DAOContracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        private SHA512 shaM = new SHA512Managed();
        private static IUserDAO _userDao;
        private static IPhotoDAO _photoDao;
        public UserLogic(IUserDAO userDao)
        {
            _userDao = userDao;
        }
        public static int BuyPhoto(string userName, int photoId)
        {
            int result = -1;
            User user = _userDao.GetUser(userName);
            double prise = _photoDao.GetPrise(photoId);
            if (user.Accaunt < prise)
            {
                result = 0;
            }
            try
            {
                if (_userDao.BuyPhoto(user.Id, photoId) && _userDao.EditAcc(-prise, user.Id))
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);                
            }

            return result;
        }
        public static int ChargeAcc(double sum, int id)
        {
            int result = 0;
            try
            {
                if (_userDao.EditAcc(sum, id))
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public static int Register(string userName, byte[] password)
        {
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
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }
    }
}
