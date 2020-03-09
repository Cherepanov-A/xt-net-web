using Entities;
using System.Collections.Generic;

namespace BLLContracts
{
    public interface IUserLogic
    {
        int BuyPhoto(string userName, int photoId, double prise, string creator);
        int ChargeAcc(double sum, string name);
        int Register(string userName, string password);
        int SetRole(int id, bool admin);
        int DeleteUser(int id);
        bool CanLogin(string name, string password);
        bool IsAdmin(string name);
        double CheckAcc(string name);
        User GetUser(string name);
        List<User> GetUsers();
    }
}
