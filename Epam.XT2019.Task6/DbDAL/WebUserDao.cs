using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.DbDAL
{
    public class WebUserDao : IWebUserDao
    {
        readonly string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public bool CanLogin(string name, byte[] password)
        {

            byte[] realPassword;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Hash FROM dbo.WebUsers WHERE UserName=@name";
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                realPassword = (byte[])cmd.ExecuteScalar();
            }

            return realPassword.SequenceEqual(password);

        }

        public void DeleteUser(int id)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM dbo.WebUsers WHERE id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<WebUser> GetAll()
        {
            var webUsers = new List<WebUser>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.WebUsers";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var webUser = new WebUser();
                    webUser.Id = (int)reader["id"];
                    webUser.Name = (string)reader["userName"];
                    webUser.Password = (byte[])reader["hash"];
                    webUser.Role = (int)reader["role"];
                    webUsers.Add(webUser);
                }
            }
            return webUsers;
        }

        public bool IsAdmin(string name)
        {
            int existRole = -2;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Role FROM dbo.WebUsers WHERE UserName=@name";
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                existRole = (int)cmd.ExecuteScalar();
            }
            if (existRole == 1)
            {
                return true;
            }
            return false;
        }

        public bool SaveToFile(WebUser webUser)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT id FROM dbo.WebUsers WHERE UserName=@Name";
                cmd.Parameters.AddWithValue("@Name", webUser.Name);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                { 
                    return false;
                }
            }
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.WebUsers(UserName, Hash, Role) VALUES(@UserName, @Hash, @Role)";
                cmd.Parameters.AddWithValue("@UserName", webUser.Name);
                cmd.Parameters.Add("@Hash", SqlDbType.VarBinary).Value = webUser.Password;
                cmd.Parameters.AddWithValue("@Role", webUser.Role);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public int ToggleAdmin(int id)
        {
            int existRole = -1;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Role FROM dbo.WebUsers WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                existRole = (int)cmd.ExecuteScalar();
            }
            if (!(existRole == 0 || existRole == 1))
            {
                return -1;
            }
            int newRole = Math.Abs(existRole - 1);
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE dbo.WebUsers SET Role=@role WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add(new SqlParameter("@role", DbType.Int32) { Value = newRole });
                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
            return newRole;
        }
    }
}
