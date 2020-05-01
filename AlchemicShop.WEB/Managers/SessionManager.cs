using AlchemicShop.WEB.Models;
using System.Collections.Generic;
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

        public List<ProductViewModel> AddProduct(ProductViewModel product)
        {
            var products = GetOrCreateProductList();
            products.Add(product);
            return products;
        }
    }
}