using AlchemicShop.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlchemicShop.WEB.Managers
{
    public class SessionManager
    {
        private HttpContextBase HttpContext { get; set; }

        public SessionManager(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }

        public List<ProductViewModel> GetOrCreateProductList()
        {
            var products = HttpContext.Session["ProductList"] as List<ProductViewModel>;
            if (products == null)
            {
                products = new List<ProductViewModel>();
            }
            HttpContext.Session["ProductList"] = products;
            return products;
        }

        public void AddProduct(ProductViewModel product)
        {
            var products = GetOrCreateProductList();
            products.Add(product);
        }

        public void DeleteProduct(int? id)
        {
            var products = GetOrCreateProductList();
            var deleteItem = products.Where(x => x.Id == id).FirstOrDefault();
            products.Remove(deleteItem);
        }

        public ProductViewModel EditProduct(ProductViewModel product)
        {
            var products = GetOrCreateProductList();
            var editItem = products.Where(x => x.Id == product.Id).FirstOrDefault();
            editItem.Amount = product.Amount;
            return editItem;

        }

        public ProductViewModel GetIdProduct(int? id)
        {
            var products = GetOrCreateProductList();
            return products.Where(x => x.Id == id).FirstOrDefault();

        }
    }
}