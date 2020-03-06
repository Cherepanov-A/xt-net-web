
namespace BLLContracts
{
    public interface IUserLogic
    {
        int BuyPhoto(string userName, int photoId, double prise);
        int ChargeAcc(double sum, int id);
        int Register(string userName, string password);
        int SetRole(int id, bool admin);
        int DeleteUser(int id);
        bool CanLogin(string name, string password);
    }
}
