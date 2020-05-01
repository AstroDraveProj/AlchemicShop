using AlchemicShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlchemicShop.BLL.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductDTO productDto);
        void EditProduct(ProductDTO productDTO);
        ProductDTO GetProduct(int? id);
        void Delete(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}