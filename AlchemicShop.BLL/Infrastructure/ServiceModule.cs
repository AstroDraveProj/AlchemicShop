using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Repositories;
using Ninject.Modules;

namespace AlchemicShop.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<AlchUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
