using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Helpers;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;

namespace AlchemicShop.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _dbOperation { get; set; }
        public AccountService(IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public UserDTO GetAccount(string login, string password)
        {
            var userAccount = _dbOperation.Accounts.GetUserAccount(login, password);

            return Mapper.Mapping<User, UserDTO>(userAccount);

        }
    }
}
