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
        private readonly string _lnkpath = Path.Combine(Directory.GetCurrentDirectory(), "Links");
        public List<Award> GetAwards()
        {
            List<Award> awards = new List<Award>();
            if (File.Exists(_path))
            {
                var getAwardsStream = File.OpenRead(_path);
                XmlSerializer xAward = new XmlSerializer(typeof(List<Award>));
                awards = (List<Award>)xAward.Deserialize(getAwardsStream);
                getAwardsStream.Close();
            }
            return awards;
        }

        public List<Link> GetLink()
        {
            List<Link> links = new List<Link>();
            if (File.Exists(_lnkpath))
            {
                var getLinksStream = File.OpenRead(_lnkpath);
                XmlSerializer xLink = new XmlSerializer(typeof(List<Link>));
                links = (List<Link>)xLink.Deserialize(getLinksStream);
                getLinksStream.Close();
            }
            return links;
        }

        public void SaveLink(List<Link> links)
        {
            XmlSerializer xLink = new XmlSerializer(typeof(List<Link>));
            var createLinksStream = File.Create(_lnkpath);
            xLink.Serialize(createLinksStream, links);
            createLinksStream.Close();
        }

        public void SaveAward(List<Award> awards)
        {
            XmlSerializer xAward = new XmlSerializer(typeof(List<Award>));
            var createAwardsStream = File.Create(_path);
            xAward.Serialize(createAwardsStream, awards);
            createAwardsStream.Close();
        }
    }
}
