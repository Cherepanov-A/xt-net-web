using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT2019.Task6.DalContracts;
using Epam.XT2019.Task6.Entities;
using Epam.XT2019.Task6.LogicContracts;

namespace Epam.XT2019.Task6.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao _awardDao;
        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }
        public List<Award> DisplayAwards()
        {
            List<Award> awards = new List<Award>();
            try
            {
                awards = _awardDao.GetAwards();
            }
            catch (Exception e)
            {
                logIt(e.Message);
            }
            return awards;
        }

        public bool Reward(int userId, int awardId)
        {
            try
            {                
                var link = new Link();
                link.UsId = userId;
                link.AwId = awardId;                
                _awardDao.SaveLink(link);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public bool DeleteAward(int awardId)
        {            
            try
            {
                _awardDao.DeleteAward(awardId);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public bool CreateAward(string name)
        {
            try
            {
                Award award = new Award();                
                award.Name = name;                
                _awardDao.SaveAward(award);
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }
        private void logIt(string message)
        {
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\log.txt", message + Environment.NewLine);
        }

        public List<Award> DisplayUserAwards(int userId)
        {
            List<Link> lnk = _awardDao.GetLink();
            var awsIds = lnk.Where(link => link.UsId == userId).ToList<Link>();
            var allAwards = _awardDao.GetAwards();
            var userAwards = new List<Award>();
            for (int i = 0; i < awsIds.Count; i++)
            {
                for (int j = 0; j < allAwards.Count; j++)
                {
                    if (awsIds[i].AwId == awsIds[j].AwId)
                    {
                        userAwards.Add(allAwards[j]);
                    }
                }
            }            
            return userAwards;
        }
    }
}
