using Epam.XT2019.Task6.BLL;
using Epam.XT2019.Task6.DAL;
using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.LogicContracts;
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
        private static string _path = Directory.GetCurrentDirectory()+"\\sdhvfbshdbfasdj";
        private static IUserDao _uDao;
        public static IUserDao UDao => _uDao;// ?? (_uDao = new UserDao());
        private static IUserLogic _uLogic;
        public static IUserLogic ULogic => _uLogic;// ?? (_uLogic = new UserLogic(UDao));
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
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
                //File.Create(_path);
                var openCfgStream = File.Open(_path, FileMode.Create);
                XmlSerializer xCfg = new XmlSerializer(typeof(CfgDto));
                config.Dal = "default";
                config.Logic = "default";
                xCfg.Serialize(openCfgStream, config);
            }
            switch (config.Dal)
            {
                default:
                    _uDao = _uDao ?? (_uDao = new UserDao());
                    break;
            }
            switch (config.Logic)
            {
                default:
                    _uLogic = _uLogic ?? (_uLogic = new UserLogic(_uDao));
                    break;
            }
        }
    }
}
