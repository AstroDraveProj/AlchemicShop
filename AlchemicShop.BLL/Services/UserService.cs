using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Infrastructure;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task AddUser(UserDTO userDTO)
        {
            await _dbOperation.Users.Create(_mapper.Map<User>(userDTO));
            await _dbOperation.Save();
        }

        public async Task DeleteUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id категории", "");
            }

            var user = await _dbOperation.Users.Get(id.Value);
            if (user == null)
            {
                throw new ValidationException("Категория не найден", "");
            }
            await _dbOperation.Users.Delete(user);
            await _dbOperation.Save();
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var updatingUser = _mapper.Map<UserDTO, User>(userDTO);
            await _dbOperation.Users.Update(updatingUser);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var user = await _dbOperation.Users.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(user);
        }

        public async Task<UserDTO> GetUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id пользователя", "");
            }
            var user = await _dbOperation.Users.Get(id.Value);
            if (user == null)
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            var userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUser(string login)
        {
            return _mapper.Map<UserDTO>(await _dbOperation.Users.Find(x => x.Login == login));
        }

        public async Task<UserDTO> GetUser(string login, string password)
        {
            return _mapper.Map<UserDTO>(await _dbOperation.Users.Find(x => x.Login == login && x.Password == password));
        }

        public async Task<UserDTO> GetUserRole(string role)
        {
            return _mapper.Map<UserDTO>(await _dbOperation.Users.Find(x => x.Name == role));
        }


        public void Dispose()
        {
            _dbOperation.Dispose();
        }

    }
}
