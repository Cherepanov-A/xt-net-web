using Entities;
using System.Collections.Generic;

namespace BLLContracts
{
    public interface IPhotoLogic
    {
        int ChangePrise(double prise, int photoId);
        int DeletePhoto(int id);
        Photo GetPhoto(int id);
        Thumbnail GetThumbnail(int id);
        int IncRating(int userId, int photoId);
        int AddPhoto(string name, string contentType, byte[] iData, byte[] tData, string creator);
        List<Thumbnail> GetThumbnails();
        List<Photo> GetPhotos();
    }
}
