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
        public int IncRating(int userId, int photoId)
        {
            Logger.InitLogger();
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
                    Logger.Log.Info($"Photo id = {photoId} was liked by user id = {userId}");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public int DeletePhoto(int id)
        {
            Logger.InitLogger();
            int result = 0;
            try
            {
                if (_photoDao.DeletePhoto(id))
                {
                    result = 1;
                    Logger.Log.Info($"Photo id = {id} was deleted");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                result = -1;
            }
            return result;
        }

        public Thumbnail GetThumbnail(int id)
        {
            Logger.InitLogger();
            Thumbnail thumb = new Thumbnail();
            try
            {
                thumb = _photoDao.GetThumb(id);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
            return thumb;
        }

        public Photo GetPhoto(int id)
        {
            Logger.InitLogger();
            Photo photo = new Photo();
            try
            {
                photo = _photoDao.GetPhoto(id);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
            return photo;
        }

        public int ChangePrise(double prise, int photoId)
        {
            Logger.InitLogger();
            int result = 0;
            try
            {
                if (_photoDao.SetPrise(prise, photoId))
                {
                    result = 1;
                    Logger.Log.Info($"Photo id = {photoId} new prise = {prise}");
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
