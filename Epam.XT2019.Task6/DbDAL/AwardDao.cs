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
    public class AwardDao : IAwardDao
    {
        readonly string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public void DeleteAward(int id)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM dbo.Awards WHERE id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Award> GetAwards()
        {
            var awards = new List<Award>();
            using (var con = new SqlConnection(conStr))
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Awards";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var award = new Award();
                    award.Id = (int)reader["id"];
                    award.Name = (string)reader["Name"];
                    awards.Add(award);
                }
            }
            return awards;
        }

        public List<Link> GetLink()
        {
            var links = new List<Link>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.UsersAws";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                var link = new Link();
                    link.UsId = (int)reader["userId"];
                    link.AwId = (int)reader["awardId"];
                    links.Add(link);
                }
            }
            return links;
        }

        public void SaveAward(Award award)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.Awards(Name) VALUES(@Name)";
                cmd.Parameters.AddWithValue("@Name", award.Name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void SaveLink(Link link)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.UsersAws(userId, AwardId) VALUES(@userId, @AwardId)";
                cmd.Parameters.AddWithValue("@userId", link.UsId);
                cmd.Parameters.AddWithValue("@AwardId", link.AwId);
                con.Open();
                cmd.ExecuteNonQuery();                
            }
        }
    }
}
