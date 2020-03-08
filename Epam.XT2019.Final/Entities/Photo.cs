using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] FullData { get; set; }
        public byte[] ThumbData { get; set; }
        public double Prise { get; set; }
        public int Rating { get; set; }
        public string ContentType { get; set; }
        public string Creator { get; set; }
    }
}
