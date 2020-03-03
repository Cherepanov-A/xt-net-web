using Entities;

namespace BLLContracts
{
    public interface IPhotoLogic
    {
        int ChangePrise(double prise, int photoId);
        int DeletePhoto(int id);
        Photo GetPhoto(int id);
        Thumbnail GetThumbnail(int id);
        int IncRating(int userId, int photoId);
    }
}
