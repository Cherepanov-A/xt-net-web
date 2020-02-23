using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.XT2019.Task6.WebPL
{
    public class Logic
    {
        public static bool CanLogin(string login, string password)
        {
           return password == "12345";
        }
    }
}