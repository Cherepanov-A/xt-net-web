using DAOContracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDAL
{
    public class UserDAO : IUserDAO
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public bool BuyPhoto(int id)
        {
            throw new NotImplementedException();
        }

        public bool ChargeAcc(double sum)
        {
            throw new NotImplementedException();
        }
        public bool CheckUserExists(int id)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT id FROM dbo.Users WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.Read();
            }            
        }
        public bool SaveUser(User user)
        {
            int result = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.WebUsers(UserName, Hash, Role) VALUES(@userName, @hash, @role, @accaunt)";
                cmd.Parameters.AddWithValue("@userName", user.Name);
                cmd.Parameters.Add("@hash", SqlDbType.VarBinary).Value = user.Password;
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@accaunt", user.Accaunt);
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result>0;
        }

        public bool DeleteUser(string name)
        {
            int id = -1;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Id FROM dbo.Users WHERE Name = @name";
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = (int)reader["Id"];                   
                }
            }
            if (id<0)
            {
                return false;
            }
            int result = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM dbo.Users WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            if (result > 0)
            {
                using (var con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM dbo.Likes WHERE UserId=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }                
            }
            else
            {
                return false;
            }
            return true;
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool ToggleAdmin(string name)
        {
            throw new NotImplementedException();
        }
    }
}
