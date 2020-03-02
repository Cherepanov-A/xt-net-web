using BLLContracts;
using DAOContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhotoLogic : IPhotoLogic
    {
        private static IPhotoDAO _photoDao;
        public PhotoLogic(IPhotoDAO photoDao)
        {
            _photoDao = photoDao;
        }
        public static bool IncRating(int userId, int photoId)
        {
            if (_photoDao.GetLikes(photoId).Contains(userId))
            {
                return false;
            }
            return _photoDao.IncRating(userId, photoId);
        }
    }
}
