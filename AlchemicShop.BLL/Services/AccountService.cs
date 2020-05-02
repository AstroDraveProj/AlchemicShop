using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Services
{
    public class AccountService : IUserAccountService
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

        public async Task<UserDTO> GetUserAsync(UserDTO item)
        {
            return _mapper.Map<UserDTO>(await _dbOperation.Accounts.GetUserAsync(_mapper.Map<User>(item)));
        }
    }
}
