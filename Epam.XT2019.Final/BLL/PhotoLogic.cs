using BLLContracts;
using DAOContracts;
using Entities;
using System;

namespace BLL
{
    public class PhotoLogic : IPhotoLogic
    {
        private static IPhotoDAO _photoDao;
        public PhotoLogic(IPhotoDAO photoDao)
        {
            _photoDao = photoDao;
        }
        public static int IncRating(int userId, int photoId)
        {
            int result = 0;
            try
            {
                if (_photoDao.GetLikes(photoId).Contains(userId))
                {
                    return 0;
                }
                if (_photoDao.IncRating(userId, photoId))
                {
                    result = 1;
                }               
            }
            catch (Exception e)
            {
                Logger.InitLogger();
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }
        public static int DeletePhoto(int id)
        {
            int result = 0;
            try
            {
                if (_photoDao.DeletePhoto(id))
                {
                 result = 1;
                }
            }
            catch (Exception e)
            {
                Logger.InitLogger();
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public static Thumbnail GetThumbnail(int id)
        {
            Thumbnail thumb = new Thumbnail();
            try
            {
                thumb = _photoDao.GetThumb(id);
            }
            catch (Exception e)
            {
                Logger.InitLogger();
                Logger.Log.Error(e.Message);                
            }
            return thumb;
        }
        public static Photo GetPhoto(int id)
        {
            Photo photo = new Photo();
            try
            {
                photo = _photoDao.GetPhoto(id);
            }
            catch (Exception e)
            {
                Logger.InitLogger();
                Logger.Log.Error(e.Message);
            }
            return photo;
        }
        public static int ChangePrise(double prise, int photoId)
        {
            int result = 0;
            try
            {
                if (_photoDao.ChangePrise(prise, photoId))
                {
                    result = 1;
                }
            }
            catch (Exception e)
            {
                Logger.InitLogger();
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }
    }
}
