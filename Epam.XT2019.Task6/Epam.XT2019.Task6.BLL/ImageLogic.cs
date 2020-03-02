using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using Epam.XT2019.Task6.LogicContracts;

namespace Epam.XT2019.Task6.BLL
{
    public class ImageLogic : IImageLogic
    {
        private IImageDao _imageDao;
        public ImageLogic(IImageDao imageDao)
        {
            _imageDao = imageDao;
        }
        public List<Image> DisplayImages()
        {
            List<Image> images = new List<Image>();
            try
            {
                images = _imageDao.GetImages();
            }
            catch (Exception e)
            {
                logIt(e.Message);
            }
            return images;
        }

        public bool SetUserImage(int userId, int imageId)
        {
            try
            {
                var link = new Link();
                link.UsId = userId;
                link.AwId = imageId;
                _imageDao.SaveLink(link);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public bool DeleteImage(int imageId)
        {
            try
            {
                _imageDao.DeleteImage(imageId);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public bool SaveImage(string name, string contentType, byte[] data)
        {
            try
            {
                Image image = new Image();
                image.Name = name;
                image.ContentType = contentType;
                image.Data = data;
                _imageDao.SaveImage(image);
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

        public List<Image> DisplayUserImage(int userId)
        {
            List<Link> lnk = _imageDao.GetLink();
            var userLinks = lnk.Where(link => link.UsId == userId).ToList<Link>();
            var userImIds = new List<int>();
            for (int i = 0; i < userLinks.Count; i++)
            {
                userImIds.Add(userLinks[i].AwId);
            }
            var allImages = _imageDao.GetImages();
            var userImages = new List<Image>();
            for (int i = 0; i < userImIds.Count; i++)
            {
                for (int j = 0; j < allImages.Count; j++)
                {
                    if (userImIds[i] == allImages[j].Id)
                    {
                        if (userImages.Contains(allImages[j]))
                        {
                            break;
                        }
                        else
                        {
                            userImages.Add(allImages[j]);
                        }
                    }
                }
            }
            return userImages;
        }
    }
}


