using AlchemicShop.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlchemicShop.WEB.Memento
{
    public class ProductHistory
    {
        public HttpContextBase HttpContext { get; private set; }

        public ProductHistory(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }

        public List<ProductViewModel> GetOrCreateProductList()
        {
            var products = HttpContext.Session["ProductHistory"] as List<ProductViewModel>;
            if (products == null)
            {
                products = new List<ProductViewModel>();
            }
            HttpContext.Session["ProductHistory"] = products;
            return products;
        }

        public void AddProduct(ProductViewModel product)
        {
            var products = GetOrCreateProductList();
            int counter = 0;

            foreach (var item in products)
            {
                if (item.Id == product.Id
                    && item.Name == product.Name
                    && item.Price == product.Price
                    && item.Description == product.Description
                    && item.CategoryId == product.CategoryId
                    && item.Amount == product.Amount
                    )
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                products.Add(product);
            }
        }

        public void ReturnProduct(int? id)
        {
            var products = GetOrCreateProductList();

            products.Remove(products.Where(x => x.Id == id).FirstOrDefault());
        }

        public ProductViewModel GetProductId(int id)
        {
            var products = GetOrCreateProductList();
            return products.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}