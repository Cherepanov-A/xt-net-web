using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.DbDAL
{
    public class UserDao : IUserDao
    {
        readonly string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public void DeleteUser(int id)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM dbo.Users WHERE id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<User> GetAll()
        {
            var users = new List<User>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Users";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User();
                    user.Id = (int)reader["id"];
                    user.Name = (string)reader["Name"];
                    user.Age = (int)reader["Age"];
                    user.DateOfBirth = (string)reader["DateOfBirth"];
                    users.Add(user);
                }
            }
            return users;
        }

        public void SaveToFile(User user)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.Users(Name, DateOfBirth, Age) VALUES(@Name, @DateOfBirth, @Age)";
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                con.Open();
                cmd.ExecuteNonQuery();
            }  
        }
    }
}
