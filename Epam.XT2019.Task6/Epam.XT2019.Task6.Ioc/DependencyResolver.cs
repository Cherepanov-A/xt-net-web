﻿using Epam.XT2019.Task6.BLL;
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
        private static string _path = Path.Combine(Directory.GetCurrentDirectory(),"cfg");
        private static IUserDao _uDao;
        public static IUserDao UDao => _uDao;
        private static IUserLogic _uLogic;
        public static IUserLogic ULogic => _uLogic;
        private static IAwardDao _aDao;
        public static IAwardDao ADao => _aDao;
        private static IAwardLogic _aLogic;
        public static IAwardLogic ALogic => _aLogic;
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
                xCfg.Serialize(openCfgStream, config);
                openCfgStream.Close();
            }
            switch (config.UserDao)
            {
                default:
                    _uDao = _uDao ?? (_uDao = new UserDao());
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
                default:
                    _aDao = _aDao ?? (_aDao = new AwardDao());
                    break;
            }
            switch (config.AwardLogic)
            {
                default:
                    _aLogic = _aLogic ?? (_aLogic = new AwardLogic(_aDao));
                    break;
            }
        }
    }
}