using AlchemicShop.BLL.DTO;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IUserAccountService
    {
        Task<UserDTO> GetUserAsync(UserDTO item);
    }
}
