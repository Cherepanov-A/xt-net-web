using Entities;
using System.Collections.Generic;

namespace DAOContracts
{
    public interface IPhotoDAO
    {
        bool SavePhoto(Photo photo);
        Photo GetPhoto(int id);
        Thumbnail GetThumb(int id);
        bool DeletePhoto(int id);
        bool IncRating(int userId, int photoId);
        bool SetPrise(double prise, int photoId);
        double GetPrise(int photoId);
        List<int> GetLikes(int photoId);
    }
}
 