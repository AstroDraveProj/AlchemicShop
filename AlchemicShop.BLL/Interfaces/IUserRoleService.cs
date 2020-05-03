using AlchemicShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IUserRoleService
    {
        Task AddUserRole(UserRoleDTO userRoleDTO);

        Task<UserRoleDTO> GetUserRole(int? id);

        Task<IEnumerable<UserRoleDTO>> GetUserRoles();

        Task EditUserRole(UserRoleDTO userRoleDTO);

        Task DeleteUserRole(int? id);

        void Dispose();
    }
}
