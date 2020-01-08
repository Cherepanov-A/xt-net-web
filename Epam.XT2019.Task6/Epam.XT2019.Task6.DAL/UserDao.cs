using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Epam.XT2019.Task6.DAL
{
    public class UserDao : IUserDao
    {
        private string _path = Directory.GetCurrentDirectory() + "\\Users";


        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            if (File.Exists(_path))
            {
                var getUsersStream = File.OpenRead(_path);
                XmlSerializer xUser = new XmlSerializer(typeof(List<User>));
                users = (List<User>)xUser.Deserialize(getUsersStream);
                getUsersStream.Close();
            }
            return users;
        }

        public void SaveToFile(List<User> users)
        {
            XmlSerializer xUser = new XmlSerializer(typeof(List<User>));
            var createUsersStream = File.Create(_path);
            xUser.Serialize(createUsersStream, users);
            createUsersStream.Close();
        }

    }
}
