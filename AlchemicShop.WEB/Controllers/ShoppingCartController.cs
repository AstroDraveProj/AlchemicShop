using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Managers;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ShoppingCartController(
            IMapper mapper,
            ICategoryService categoryService,
            IProductService productService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<ActionResult> AddProduct(int? id)
        {
            if (id != null)
            {
                var session = new SessionManager(HttpContext);
                var product = _mapper.Map<ProductViewModel>
                    (await _productService.GetProduct(id));
                product.Amount = 1;
                session.AddProduct(product);
                return RedirectToAction(nameof(GetCart));
            }
            return RedirectToAction(nameof(GetCart));
        }

        public ActionResult DeleteCartItem(int? id)
        {
            if (id != null)
            {
                var session = new SessionManager(HttpContext);
                if (session != null)
                {
                    session.DeleteProduct(id);
                    return RedirectToAction(nameof(GetCart));
                }
            }
            return RedirectToAction(nameof(GetCart));
        }

        public ActionResult EditCartAmount(int? id)
        {
            if (id != null)
            {
                var session = new SessionManager(HttpContext);
                if (session != null)
                {
                    return View(session.GetIdProduct(id));
                }
            }
            return RedirectToAction(nameof(GetCart));
        }

        [HttpPost]
        public ActionResult EditCartAmount(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var session = new SessionManager(HttpContext);
                session.EditProduct(product);
                return RedirectToAction(nameof(GetCart));
            }
            return View(product);
        }

        public ActionResult GetCart()
        {
            var session = new SessionManager(HttpContext);
            return View(session.GetOrCreateProductList());
        }

        public ActionResult RemoveCart()
        {
            var session = new SessionManager(HttpContext);
            session.RemoveAllProduct();
            return RedirectToAction(nameof(GetCart));
        }
    }
}