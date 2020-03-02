using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.Entities
{
    public class Image
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }
    }
}
