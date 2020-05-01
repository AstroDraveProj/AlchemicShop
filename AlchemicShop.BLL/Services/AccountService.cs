using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;
        public AccountService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetAccount(string login, string password)
        {
            var userAccount = await _dbOperation.Accounts.GetUserAccount(login, password);

            return  _mapper.Map<User, UserDTO>(userAccount);

        }
    }
}
