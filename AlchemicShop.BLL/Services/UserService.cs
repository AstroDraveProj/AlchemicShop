using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AlchemicShop.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddUser(UserDTO userDTO)
        {

        }
        public IEnumerable<UserDTO> GetUsers()
        {
            return Mapper.UserMap(Database.Users.GetAll().ToList());
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id пользователя", "");
            }
            var user = Database.Users.Get(id.Value);
            if (user == null)
            {
                throw new ValidationException("Пользователь не найден", "");
            }

            var userDTO = Mapper.UserMap(user);
            return userDTO;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
