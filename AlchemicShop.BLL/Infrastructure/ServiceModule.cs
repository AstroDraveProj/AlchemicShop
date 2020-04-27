using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Repositories;
using Ninject.Modules;

namespace AlchemicShop.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<AlchUnitOfWork>().WithConstructorArgument(connectionString);

        }
    }
}
