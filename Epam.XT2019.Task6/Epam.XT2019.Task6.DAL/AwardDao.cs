using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Epam.XT2019.Task6.DAL
{
    public class AwardDao : IAwardDao
    {
        private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "Awards");
        public List<Award> GetAll()
        {
            List<Award> awards = new List<Award>();
            if (File.Exists(_path))
            {
                var getAwardsStream = File.OpenRead(_path);
                XmlSerializer xAward = new XmlSerializer(typeof(List<User>));
                awards = (List<Award>)xAward.Deserialize(getAwardsStream);
                getAwardsStream.Close();
            }
            return awards;
        }
        public void SaveToFile(List<Award> awards)
        {
            XmlSerializer xAward = new XmlSerializer(typeof(List<Award>));
            var createAwardsStream = File.Create(_path);
            xAward.Serialize(createAwardsStream, awards);
            createAwardsStream.Close();
        }
    }
}
