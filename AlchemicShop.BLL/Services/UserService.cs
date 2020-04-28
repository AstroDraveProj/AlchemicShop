using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using AlchemicShop.BLL.Helpers;

namespace AlchemicShop.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _dbOperation { get; set; }
        public UserService(IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public void AddUser(UserDTO userDTO)
        {
            _dbOperation.Users.Create(Mapper.Mapping<UserDTO, User>(userDTO));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return Mapper.Mapping<User, UserDTO>(_dbOperation.Users.GetAll().ToList());
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

            var userDTO = Mapper.Mapping<User, UserDTO>(user);
            return userDTO;
        }
        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
