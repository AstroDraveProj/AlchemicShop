using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AlchemicShop.BLL.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;

        public UserRoleService(
             IMapper mapper,
             IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public Task AddUserRole(UserRoleDTO userRoleDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserRole(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task EditUserRole(UserRoleDTO userRoleDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRoleDTO> GetUserRole(int? id)
        {
            //if (id == null)
            //{
            //    throw new ValidationException("Category not foundid", "");
            //}
            int i = 1;
            var userRole = await _dbOperation.UserRoles.Get(i);
            if (userRole == null)
            {
                throw new ValidationException("Category not found", "");
            }
            return _mapper.Map<UserRoleDTO>(userRole);
        }

        public async Task<IEnumerable<UserRoleDTO>> GetUserRoles()
        {
            return _mapper.Map<List<UserRoleDTO>>
                (await _dbOperation.UserRoles.GetAll());
        }
    }
}
