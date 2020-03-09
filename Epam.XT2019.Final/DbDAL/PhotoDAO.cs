using DAOContracts;
using Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DbDAL
{
    public class PhotoDAO : IPhotoDAO
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public bool SetPrise(double prise, int photoId)
        {
            int result = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE dbo.Photos SET Prise=@prise WHERE id = @photoId";
                cmd.Parameters.AddWithValue("@photoId", photoId);
                cmd.Parameters.Add(new SqlParameter("@role", DbType.Double) { Value = prise });
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool DeletePhoto(int id)
        {
            int tmp = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM dbo.Photos WHERE id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                tmp = cmd.ExecuteNonQuery();
            }
            return tmp > 0;
        }

        public Photo GetPhoto(int id)
        {
            var photo = new Photo();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Photos WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    photo.Id = (int)reader["Id"];
                    photo.Name = (string)reader["Name"];
                    photo.FullData = (byte[])reader["FullData"];
                    photo.ThumbData = (byte[])reader["ThumbData"];
                    photo.Prise = (double)reader["Prise"];
                    photo.Rating = (int)reader["Rating"];
                    photo.ContentType = (string)reader["ContentType"];
                    photo.Creator = (string)reader["Creator"];
                }
            }
            return photo;
        }

        public Thumbnail GetThumb(int id)
        {
            var thumb = new Thumbnail();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Photos WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    thumb.Id = (int)reader["Id"];
                    thumb.Name = (string)reader["Name"];
                    thumb.ThumbData = (byte[])reader["ThumbData"];
                    thumb.Prise = (double)reader["Prise"];
                    thumb.Rating = (int)reader["Rating"];
                    thumb.ContentType = (string)reader["ContentType"];
                }
            }
            return thumb;
        }

        public List<int> GetLikes(int photoId)
        {
            List<int> uIds = new List<int>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UserId FROM dbo.Likes WHERE Id = @photoId";
                cmd.Parameters.AddWithValue("@photoId", photoId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    uIds.Add((int)reader["UserId"]);
                }
            }
            return uIds;
        }

        public bool IncRating(int userId, int photoId)
        {
            int rating = -1;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UserId FROM dbo.Photos WHERE Id = @photoId";
                cmd.Parameters.AddWithValue("@photoId", photoId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rating = (int)reader["Rating"];
                }
                else return false;
            }
            int newRating = rating++;
            int result = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE dbo.Photos SET Rating=@rating WHERE id = @photoId";
                cmd.Parameters.AddWithValue("@photoId", photoId);
                cmd.Parameters.Add(new SqlParameter("@role", DbType.Int32) { Value = newRating });
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool SavePhoto(Photo photo)
        {
            int id = -1;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO dbo.Photos (Name, FullData, ThumbData, Prise, Rating, ContentType, Creator) " +
                                  "VALUES (@name, @fullData, @thumbData, @prise, @rating, @contentType, @creator);" +
                                  "SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@name", photo.Name);
                cmd.Parameters.AddWithValue("@fullData", photo.FullData);
                cmd.Parameters.AddWithValue("@thumbData", photo.ThumbData);
                cmd.Parameters.AddWithValue("@prise", photo.Prise);
                cmd.Parameters.AddWithValue("@rating", photo.Rating);
                cmd.Parameters.AddWithValue("@contentType", photo.ContentType);
                cmd.Parameters.AddWithValue("@creator", photo.Creator);
                con.Open();
                id = (int)(decimal)cmd.ExecuteScalar();
            }
            return id > -1;
        }

        public double GetPrise(int photoId)
        {
            double prise = 0;
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Prise FROM dbo.Photos WHERE Id = @photoId";
                cmd.Parameters.AddWithValue("@photoId", photoId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    prise = (double)reader["Prise"];
                }
            }
            return prise;
        }

        public List<Thumbnail> GetThumbnails()
        {
            var photos = new List<Thumbnail>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, ThumbData, ContentType, Prise, Rating FROM dbo.Photos";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var thumbnail = new Thumbnail();
                    thumbnail.Id = (int)reader["Id"];
                    thumbnail.Name = (string)reader["Name"];
                    thumbnail.ThumbData = (byte[])reader["ThumbData"];
                    thumbnail.ContentType = (string)reader["ContentType"];
                    thumbnail.Prise = (double)reader["Prise"];
                    thumbnail.Rating = (int)reader["Rating"];
                    photos.Add(thumbnail);
                }
            }
            return photos;
        }
        public List<Photo> GetPhotos()
        {
            var photos = new List<Photo>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Photos";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var photo = new Photo();
                    photo.Id = (int)reader["Id"];
                    photo.Name = (string)reader["Name"];
                    photo.ThumbData = (byte[])reader["ThumbData"];
                    photo.ContentType = (string)reader["ContentType"];
                    photo.Prise = (double)reader["Prise"];
                    photo.Rating = (int)reader["Rating"];
                    photo.FullData = (byte[])reader["FullData"];
                    photo.Creator = (string)reader["Creator"];
                    photos.Add(photo);
                }
            }
            return photos;
        }
        public List<Photo> ShowOwnPhotos(string userName)
        {
            List<Photo> ownPhotos = new List<Photo>();
            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Photos WHERE Creator = @userName";
                cmd.Parameters.AddWithValue("@userName", userName);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Photo photo = new Photo();
                    photo.Id = (int)reader["Id"];
                    photo.Name = (string)reader["Name"];
                    photo.FullData = (byte[])reader["FullData"];
                    photo.ThumbData = (byte[])reader["ThumbData"];
                    photo.Prise = (double)reader["Prise"];
                    photo.Rating = (int)reader["Rating"];
                    photo.ContentType = (string)reader["ContentType"];
                    photo.Creator = (string)reader["Creator"];
                    ownPhotos.Add(photo);
                }
            }
            return ownPhotos;
        }
        public List<Photo> ShowPurchasedPhotos(int userId)
        {
            List<int> photoIds = new List<int>();
            List<Photo> purPhotos = new List<Photo>();

            using (var con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT PhotoId FROM dbo.Purchased WHERE UserId = @userId";
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    photoIds.Add((int)reader["PhotoId"]);
                }
            }
            for (int i = 0; i < photoIds.Count; i++)
            {
                Photo photo = new Photo();
                using (var con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM dbo.Photos WHERE Id = @photoId";
                    cmd.Parameters.AddWithValue("@photoId", photoIds[i]);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        photo.Id = (int)reader["Id"];
                        photo.Name = (string)reader["Name"];
                        photo.FullData = (byte[])reader["FullData"];
                        photo.ThumbData = (byte[])reader["ThumbData"];
                        photo.Prise = (double)reader["Prise"];
                        photo.Rating = (int)reader["Rating"];
                        photo.ContentType = (string)reader["ContentType"];
                        photo.Creator = (string)reader["Creator"];
                        purPhotos.Add(photo);
                    }
                }
            }
            return purPhotos;
        }
    }
}
