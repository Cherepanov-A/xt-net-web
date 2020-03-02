using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.XT2019.Task6.DbDAL
{
   
    public class ImageDao : IImageDao
    {
        readonly string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public void SaveImage(Image image)
        {
            int id = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.Images (Data, Name, ContentType) VALUES (@data, @name, @contentType);" +
                                  "SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@data", image.Data);
                cmd.Parameters.AddWithValue("@name", image.Name);
                cmd.Parameters.AddWithValue("@contentType", image.ContentType);
                con.Open();
                id = (int)(decimal)cmd.ExecuteScalar();
            }
        }
        public void DeleteImage(int id)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM dbo.Images WHERE id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Image> GetImages()
        {
            var images = new List<Image>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Images";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var image = new Image();
                    image.Id = (int)reader["id"];
                    image.Name = (string)reader["Name"];
                    image.Data = (byte[])reader["Data"];
                    image.ContentType = (string)reader["ContentType"];
                    images.Add(image);
                }
            }
            return images;
        }

        public List<Link> GetLink()
        {
            var links = new List<Link>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.UsImgs";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var link = new Link();
                    link.UsId = (int)reader["userId"];
                    link.AwId = (int)reader["imageId"];
                    links.Add(link);
                }
            }
            return links;
        }
        public void SaveLink(Link link)
        {
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.UsImgs(userId, imageId) VALUES(@userId, @imageId)";
                cmd.Parameters.AddWithValue("@userId", link.UsId);
                cmd.Parameters.AddWithValue("@imageId", link.AwId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
