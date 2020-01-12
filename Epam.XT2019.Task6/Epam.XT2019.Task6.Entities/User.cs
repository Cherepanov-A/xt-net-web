using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.Entities
{
    [Serializable]
    public class User
    {
        public string Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
