using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.Entities
{
    [Serializable]
    public class Linker
    {
        public Dictionary<string, string> Links { get; set; }
    }
}
