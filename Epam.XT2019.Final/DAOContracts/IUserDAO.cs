using Entities;
using System.Collections.Generic;

namespace DAOContracts
{
    public interface IUserDAO
    {
        bool SaveUser(User user);
        bool DeleteUser(string name);
        bool GetRole(int id);
        bool SetRole(int id, bool role);
        List<User> GetUsers();
        bool BuyPhoto(int userId, int photoId);
        bool ChargeAcc(double sum, int id);
        double CheckAcc(int id);
        bool CheckUserExists(int id);
    }
}
