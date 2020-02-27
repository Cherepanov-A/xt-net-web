using System;
using Epam.XT2019.Task6.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.DalContracts
{
    public interface IImageDao
    {
        void DeleteImage(int id);
        List<Image> GetImages();
        List<Link> GetLink();
        void SaveImage(Image image);
        void SaveLink(Link link);
    }
}
