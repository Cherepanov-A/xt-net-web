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
        string path = Directory.GetCurrentDirectory() + "\\Users.xml";
        public void DeleteFromFile(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            var openUsersStream = File.OpenRead(path);
            XmlSerializer xUser = new XmlSerializer(typeof(List<User>));
            if (FileCheck())
            {
                users = (List<User>)xUser.Deserialize(openUsersStream);
            }
            else
            {
                File.Create(path);
                User user = new User();
                user.Name = "test user";
                user.Id = "0";
                user.DateOfBirth = DateTime.Now.AddHours(-1);
                users.Add(user);
                xUser.Serialize(openUsersStream, users);
            }
            return users;
        }

        public void SaveToFile(User user)
        {
            var users = new List<User>();
            XmlSerializer xUser = new XmlSerializer(typeof(List<User>));
            var openUsersStream = File.OpenRead(path);
            if (FileCheck())
            {
                users = (List<User>)xUser.Deserialize(openUsersStream);
            }
            else
            {
                File.Create(path);
            }
            users.Add(user);
            xUser.Serialize(openUsersStream, users);
        }

        private bool FileCheck()
        {
            return (File.Exists(path)) ? true : false;
        }
    }
}
