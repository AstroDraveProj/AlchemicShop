using AlchemicShop.BLL.DTO;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IAccountService
    {
        UserDTO GetAccount(string login,string password);
    }
}
