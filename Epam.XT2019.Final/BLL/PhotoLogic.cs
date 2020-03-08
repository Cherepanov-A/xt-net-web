using BLLContracts;
using DAOContracts;
using Entities;
using System;
using System.Collections.Generic;

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
        public int AddPhoto(string name, string contentType, byte[] iData, byte[] tData, string creator)
        {
            Logger.InitLogger();
            int result = -1;
            try
            {
                Photo photo = new Photo();
                photo.Name = name;
                photo.ContentType = contentType;
                photo.FullData = iData;
                photo.ThumbData = tData;
                photo.Prise = 1;
                photo.Rating = 0;
                photo.Creator = creator;
                if (_photoDao.SavePhoto(photo))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
                return -1;
            }
            return result;
        }

        public List<Thumbnail> GetThumbnails()
        {
            Logger.InitLogger();
            List<Thumbnail> photos = new List<Thumbnail>();
            try
            {
                photos = _photoDao.GetThumbnails();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
            return photos;
        }

        public List<Photo> GetPhotos()
        {
            Logger.InitLogger();
            List<Photo> photos = new List<Photo>();
            try
            {
                photos = _photoDao.GetPhotos();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);
            }
            return photos;
        }
    }
}
