using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Services
{
    public class SortingService : ISortService
    {
        private readonly IUnitOfWork _dbOperation;
        private readonly IMapper _mapper;

        public SortingService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _dbOperation = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> SortProductPrice(string sortOrder)
        {
            var product = await _dbOperation.Products.GetAllAsync();

            switch (sortOrder)
            {
                case "price_desc":
                    product = product.OrderByDescending(x => x.Price).ToList();
                    break;
                case "amount_desc":
                    product = product.OrderByDescending(x => x.Amount).ToList();
                    break;
                default:
                    product = product.OrderBy(x => x.Name).ToList();
                    break;
            }
            return _mapper.Map<IEnumerable<ProductDTO>>
                (product).ToList();
        }
    }
}