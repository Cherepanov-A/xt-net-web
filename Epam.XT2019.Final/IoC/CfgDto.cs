using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    [Serializable]
    internal class CfgDto
    {
        internal string UserDAO { get; set; }
        internal string UserLogic { get; set; }
        internal string PhotoDAO { get; set; }
        internal string PhotoLogic { get; set; }       
    }
}
