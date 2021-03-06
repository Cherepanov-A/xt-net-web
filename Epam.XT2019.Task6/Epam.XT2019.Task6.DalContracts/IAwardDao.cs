﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT2019.Task6.Entities;

namespace Epam.XT2019.Task6.DalContracts
{
    public interface IAwardDao
    {
        void SaveAward(Award award);
        void DeleteAward(int id);
        List<Award> GetAwards();
        List<Link> GetLink();
        void SaveLink(Link link);
    }
}
