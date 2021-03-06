﻿using System.Collections.Generic;
using Epam.XT2019.Task6.Entities;

namespace Epam.XT2019.Task6.LogicContracts
{
    public interface IWebUserLogic
    {
        int CreateUser(string name, string password);
        bool DeleteUser(int Id);
        List<WebUser> DisplayUsers();
        int ToggleAdmin(int Id);
        bool CanLogin(string name, string password);
        bool IsAdmin(string name);
    }
}
