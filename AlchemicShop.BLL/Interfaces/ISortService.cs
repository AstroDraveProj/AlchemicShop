using AlchemicShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface ISortService
    {
        Task<IEnumerable<ProductDTO>> SortProductPrice(string sortOrder);
    }
}
