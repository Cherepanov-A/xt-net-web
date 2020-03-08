using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    [Serializable]
    public class CfgDto
    {
        public string UserDAO { get; set; }
        public string UserLogic { get; set; }
        public string PhotoDAO { get; set; }
        public string PhotoLogic { get; set; }       
    }
}
