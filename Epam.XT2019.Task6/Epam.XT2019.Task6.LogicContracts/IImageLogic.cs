using System;
using System.Collections.Generic;
using Epam.XT2019.Task6.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.LogicContracts
{
    public interface IImageLogic
    {
        bool SaveImage(string name, string contentType, byte[] data);
        bool DeleteImage(int imageId);
        List<Image> DisplayImages();
        List<Image> DisplayUserImage(int userId);
        bool SetUserImage(int userId, int awardId);
    }
}
