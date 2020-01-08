﻿using Epam.XT2019.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT2019.Task6.DalContracts
{
    public interface IUserDao
    {
        void SaveToFile(List<User> users);       
        List<User> GetAll();
    }
}
