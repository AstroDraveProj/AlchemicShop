using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AlchemicShop.BLL.Helpers;
using AutoMapper;

namespace AlchemicShop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;
        public UserService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public void AddUser(UserDTO userDTO)
        {
            _dbOperation.Users.Create(_mapper.Map<UserDTO, User>(userDTO));
        }

        public void DeleteUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id категории", "");
            }

            var user = _dbOperation.Users.Get(id.Value);
            if (user == null)
            {
                throw new ValidationException("Категория не найден", "");
            }
            _dbOperation.Users.Delete(user);
            _dbOperation.Save();
        }

        public void UpdateUser(UserDTO userDTO)
        {
            _dbOperation.Users.Update(_mapper.Map<UserDTO, User>(userDTO));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _mapper.Map<List<User>, List<UserDTO>>(_dbOperation.Users.GetAll().ToList());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id пользователя", "");
            }
            var user = _dbOperation.Users.Get(id.Value);
            if (user == null)
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            var userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }

    }
}
