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
    public class AwardLogic:IAwardLogic
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
                awards = _awardDao.GetAll();
            }
            catch (Exception e)
            {
                logIt(e.Message);
            }
            return awards;
        }

        public bool Reward(string userId, string awardId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAward(string awardId)
        {
            var awards = _awardDao.GetAll();
            try
            {
                if (awards.Count > 0)
                {
                    var otherAwards = awards.Where(t => t.Id != awardId);
                    List<Award> redusedUsers = otherAwards.ToList<Award>();
                    _awardDao.SaveToFile(redusedUsers);
                }
                return true;
            }
            catch (Exception e)
            {
                logIt(e.Message);
                return false;
            }
        }

        public bool CreateAward(string id, string name)
        {
            Award award = new Award();
            award.Id = id;
            award.Name = name;
            try
            {
                List<Award> awards = _awardDao.GetAll();
                awards.Add(award);
                _awardDao.SaveToFile(awards);
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
    }
}
