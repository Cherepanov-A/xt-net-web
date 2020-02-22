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

        public void DeleteUser(int id)
        {
            List<User> users = GetAll();
            if (users.Count > 0)
            {
                var otherUsers = users.Where(t => t.Id != id);
                List<User> redusedUsers = otherUsers.ToList<User>();
                XmlSerializer xUser = new XmlSerializer(typeof(List<User>));
                var createUsersStream = File.Create(_path);
                xUser.Serialize(createUsersStream, redusedUsers);
                createUsersStream.Close();                
            }
        }

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

        public void SaveToFile(User user)
        {
            List<User> users = GetAll();
            if (users.Count > 0)
            {
                user.Id = users.Last<User>().Id + 1;
            }
            else
            {
                user.Id = 0;
            }
            users.Add(user);
            XmlSerializer xUser = new XmlSerializer(typeof(List<User>));
            var createUsersStream = File.Create(_path);
            xUser.Serialize(createUsersStream, users);
            createUsersStream.Close();
        }

    }
}
