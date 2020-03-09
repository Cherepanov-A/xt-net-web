using Entities;
using System.Collections.Generic;

namespace DAOContracts
{
    public interface IUserDAO
    {
        bool SaveUser(User user);
        bool DeleteUser(int id);
        bool GetRole(int id);
        bool SetRole(int id, bool role);
        User GetUser(string name);
        bool BuyPhoto(int userId, int photoId);
        bool EditAcc(double sum, int id);
        double CheckAcc(int id);
        bool CheckUserExists(string name);
        List<User> GetUsers();
        
    }
}
