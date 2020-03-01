using Entities;
using System.Collections.Generic;

namespace DAOContracts
{
    public interface IUserDAO
    {
        bool SaveUser(User user);
        bool DeleteUser(string name);
        bool ToggleAdmin(string name);
        IEnumerable<User> GetUsers();
        bool BuyPhoto(int id);
        bool ChargeAcc(double sum);
        bool CheckUserExists(int id);
    }
}
