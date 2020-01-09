using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT2019.Task6.Entities;

namespace Epam.XT2019.Task6.LogicContracts
{
    public interface IAwardLogic
    {
        List<Award> DisplayAwards();
        bool Reward(string userId, string awardId);
        bool DeleteAward(string awardId);
        bool CreateAward(string id, string name);
    }
}
