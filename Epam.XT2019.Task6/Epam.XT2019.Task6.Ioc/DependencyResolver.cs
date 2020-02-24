using Epam.XT2019.Task6.BLL;
using Epam.XT2019.Task6.DAL;
using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.LogicContracts;
using Epam.XT2019.Task6.DbDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Epam.XT2019.Task6.Ioc
{
    public static class DependencyResolver
    {        
        private static string _path = Path.Combine(Directory.GetCurrentDirectory(),"cfg");
        private static IUserDao _uDao;
        public static IUserDao UDao => _uDao;
        private static IUserLogic _uLogic;
        public static IUserLogic ULogic => _uLogic;
        private static IAwardDao _aDao;
        public static IAwardDao ADao => _aDao;
        private static IAwardLogic _aLogic;
        public static IAwardLogic ALogic => _aLogic;
        private static IWebUserDao _wuDao;
        public static IWebUserDao WUDao => _wuDao;
        private static IWebUserLogic _wuLogic;
        public static IWebUserLogic WULogic => _wuLogic;
        static DependencyResolver()
        {
            CfgDto config = new CfgDto();
            if (File.Exists(_path))
            {
            var openCfgStream = File.Open(_path, FileMode.Open);
            XmlSerializer xCfg = new XmlSerializer(typeof(CfgDto));
                config = (CfgDto)xCfg.Deserialize(openCfgStream);
            }
            else
            {
                var openCfgStream = File.Open(_path, FileMode.Create);
                XmlSerializer xCfg = new XmlSerializer(typeof(CfgDto));
                config.UserDao = "default";
                config.UserLogic = "default";
                config.AwardDao = "default";
                config.AwardLogic = "default";
                config.WebUserDao = "default";
                config.WebUserLogic = "default";
                xCfg.Serialize(openCfgStream, config);
                openCfgStream.Close();
            }
            switch (config.UserDao)
            {
                case "db":
                    _uDao = _uDao ?? (_uDao = new DbDAL.UserDao());
                    break;
                default:
                    _uDao = _uDao ?? (_uDao = new DAL.UserDao());
                    break;
            }
            switch (config.UserLogic)
            {
                default:
                    _uLogic = _uLogic ?? (_uLogic = new UserLogic(_uDao));
                    break;
            }
            switch (config.AwardDao)
            {
                case "db":
                    _aDao = _aDao ?? (_aDao = new DbDAL.AwardDao());
                    break;
                default:
                    _aDao = _aDao ?? (_aDao = new DAL.AwardDao());
                    break;
            }
            switch (config.AwardLogic)
            {
                default:
                    _aLogic = _aLogic ?? (_aLogic = new AwardLogic(_aDao));
                    break;
            }
            switch (config.WebUserDao)
            {                
                default:
                    _wuDao = _wuDao ?? (_wuDao = new DbDAL.WebUserDao());
                    break;
            }
            switch (config.WebUserLogic)
            {
                default:
                    _wuLogic = _wuLogic ?? (_wuLogic = new WebUserLogic(_wuDao));
                    break;
            }
        }
    }
}
