using AlchemicShop.BLL.DTO;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<UserDTO> GetAccount(string login,string password);
    }
}
