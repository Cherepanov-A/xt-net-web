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
        bool Reward(int userId, int awardId);
        bool DeleteAward(int awardId);
        bool CreateAward(string name);
        List<Award> DisplayUserAwards(int userId);
    }
}
