using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.Entities
{
    public class WebUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Password { get; set; }

        public int Role { get; set; }
    }
}
