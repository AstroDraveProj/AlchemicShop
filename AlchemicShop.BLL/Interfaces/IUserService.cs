using System.Collections.Generic;
using System.Threading.Tasks;
using AlchemicShop.BLL.DTO;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserDTO userDTO);

        Task DeleteUser(int? id);

        Task UpdateUser(UserDTO userDTO);

        Task<UserDTO> GetUser(int? id);

        Task<UserDTO> GetUser(string login);

        Task<UserDTO> GetUserRole(string login);

        Task<UserDTO> GetUser(string login, string password);

        Task<IEnumerable<UserDTO>> GetUsers();

        void Dispose();
    }
}