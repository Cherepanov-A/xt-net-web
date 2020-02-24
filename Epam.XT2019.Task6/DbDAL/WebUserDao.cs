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

        public void SaveToFile(WebUser webUser)
        {
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
        }

        public bool ToggleAdmin(string wname)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE dbo.WebUsers SET Role=@role WHERE UserName=@wname";
                cmd.Parameters.AddWithValue("@wname", wname);               
                cmd.Parameters.Add(new SqlParameter("@role", DbType.Int32) { Value = 1 });
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}
