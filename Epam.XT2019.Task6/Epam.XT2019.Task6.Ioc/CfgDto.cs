using System;

namespace Epam.XT2019.Task6.Ioc
{
    [Serializable]
    public class CfgDto
    {      
        public string UserDao { get; set; }
        public string UserLogic { get; set; }
        public string AwardDao { get; set; }
        public string AwardLogic { get; set; }
        public string WebUserDao { get; set; }
        public string WebUserLogic { get; set; }
    }
}