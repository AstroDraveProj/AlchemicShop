using AlchemicShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductDTO productDto);

        Task EditProduct(ProductDTO productDTO);

        Task<ProductDTO> GetProduct(int? id);

        Task Delete(int? id);

        Task<IEnumerable<ProductDTO>> GetProducts();

        void Dispose();
    }
}