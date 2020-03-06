using BLLContracts;
using DAOContracts;
using DbDAL;
using BLL;
using System.IO;
using System.Xml.Serialization;

namespace IoC
{
    public static class DependencyResolver
    {
        private static string _path = Path.Combine(Directory.GetCurrentDirectory(), "cfg");
        private static IUserDAO _uDao;
        public static IUserDAO UDao => _uDao;
        private static IUserLogic _uLogic;
        public static IUserLogic ULogic => _uLogic;
        private static IPhotoDAO _aDao;
        public static IPhotoDAO ADao => _aDao;
        private static IPhotoLogic _aLogic;
        public static IPhotoLogic ALogic => _aLogic;        
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
                config.UserDAO = "default";
                config.UserLogic = "default";
                config.PhotoDAO = "default";
                config.PhotoLogic = "default";               
                xCfg.Serialize(openCfgStream, config);
                openCfgStream.Close();
            }
            switch (config.UserDAO)
            {                
                default:
                    _uDao = _uDao ?? (_uDao = new UserDAO());
                    break;
            }
            switch (config.UserLogic)
            {
                default:
                    _uLogic = _uLogic ?? (_uLogic = new UserLogic(_uDao));
                    break;
            }
            switch (config.PhotoDAO)
            {               
                default:
                    _aDao = _aDao ?? (_aDao = new PhotoDAO());
                    break;
            }
            switch (config.PhotoLogic)
            {
                default:
                    _aLogic = _aLogic ?? (_aLogic = new PhotoLogic(_aDao));
                    break;
            }            
        }
    }
}

