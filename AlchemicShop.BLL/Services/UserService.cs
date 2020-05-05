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
            _dbOperation.Users.Create(_mapper.Map<User>(userDTO));
            await _dbOperation.Save();
        }

        public async Task DeleteUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("User not found", "");
            }

            var user = await _dbOperation.Users.GetIdAsync(id.Value);
            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }
            _dbOperation.Users.Delete(user);
            await _dbOperation.Save();
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            _dbOperation.Users.Update(_mapper.Map<User>(userDTO));
            await _dbOperation.Save();
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _dbOperation.Users.GetAllAsync());
        }

        public async Task<UserDTO> GetUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("User not found", "");
            }
            var user = await _dbOperation.Users.GetIdAsync(id);
            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUser(string login)
        {
            return _mapper.Map<UserDTO>(
                await _dbOperation.Users.FindItemAsync(x => x.Login == login));
        }

        public async Task<UserDTO> GetUser(string login, string password)
        {
            return _mapper.Map<UserDTO>(
                await _dbOperation.Users
                .FindItemAsync(x => x.Login == login && x.Password == password));
        }

        public void Dispose()
        {
            _dbOperation.Dispose();
        }
    }
}
