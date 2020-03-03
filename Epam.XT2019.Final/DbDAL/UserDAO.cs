using DAOContracts;
using Entities;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DbDAL
{
    public class UserDAO : IUserDAO
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public bool BuyPhoto(int userId, int photoId)
        {
            int result = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.Purchased(UserId, PhotoId) VALUES(@userId, @photoId)"; /*Check db name*/
                cmd.Parameters.AddWithValue("@userId", userId);                
                cmd.Parameters.AddWithValue("@photoId", photoId);                
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }

        public double CheckAcc(int id)
        {
            double result = -1;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT id FROM dbo.Users WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = (double)reader["Accaunt"];
                }
            }
            return result;
        }

        public bool EditAcc(double sum, int id)
        {
            int result = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE dbo.Users SET Accaunt=@acc WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add(new SqlParameter("@acc", DbType.Double) { Value = sum });
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool CheckUserExists(string name)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT id FROM dbo.Users WHERE Name=@name";
                cmd.Parameters.AddWithValue("@name", name);
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
                cmd.CommandText = "INSERT INTO dbo.Users(UserName, Hash, Role) VALUES(@userName, @hash, @role, @accaunt)";
                cmd.Parameters.AddWithValue("@userName", user.Name);
                cmd.Parameters.Add("@hash", SqlDbType.VarBinary).Value = user.Password;
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@accaunt", user.Accaunt);
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result>0;
        }

        public bool DeleteUser(int id)
        {            
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

        public User GetUser(string name)
        {
            var user = new User();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Users WHERE Name = @name";
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {                    
                    user.Id = (int)reader["Id"];
                    user.Name = (string)reader["Name"];
                    user.Password = (byte[])reader["Hash"];
                    user.Role = (bool)reader["Role"];
                    user.Accaunt = (double)reader["Accaunt"];                    
                }
            }
            return user;
        }        

        public bool GetRole(int id)
        {
            bool existRole = false;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Role FROM dbo.Users WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                existRole = (bool)cmd.ExecuteScalar();
            }
            return existRole;
        }

        public bool SetRole(int id, bool role)
        {
            int result = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE dbo.WebUsers SET Role=@role WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add(new SqlParameter("@role", DbType.Boolean) { Value = role });
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }
    }
}
