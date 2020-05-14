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
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(
            IMapper mapper,
            ICategoryService categoryService,
            IProductService productService,
            IShoppingCartService shoppingCartService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<ActionResult> AddProduct(int? id)
        {
            if (id != null)
            {
                var session = new SessionManager(HttpContext);
                var curCartAmount = session.GetOrCreateProductList();
                var product = _mapper.Map<ProductViewModel>
                    (await _productService.GetProduct(id));
                product.Amount = 1;

                if (curCartAmount.Count == 0)
                {
                    session.AddProduct(product);
                }
                else
                {
                    foreach (var item in curCartAmount)
                    {
                        if (item.Id == product.Id)
                        {
                            if (await _shoppingCartService.IsEnoughProduct(product.Id, item.Amount))
                            {
                                session.AddProduct(product);
                                return RedirectToAction(nameof(GetCart));
                            }
                            else
                            {
                                return RedirectToAction("GetProductList", "Product");
                            }
                        }
                    }
                }
            }
            ViewBag.AmountMsg = "Choose another amount";
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
        public async Task<ActionResult> EditCartAmount(ProductViewModel product)
        {
            if (await _productService.IsEnoughProduct(product.Id, product.Amount))
            {
                ViewBag.AmountMsg = "";
                if (ModelState.IsValid)
                {
                    var session = new SessionManager(HttpContext);
                    session.EditProduct(product);
                    return RedirectToAction(nameof(GetCart));
                }
                return View(product);
            }
            ViewBag.AmountMsg = "Choose another amount";
            return View(product);
        }

        public ActionResult GetCart()
        {
            var session = new SessionManager(HttpContext);
            var products = session.GetOrCreateProductList();
            ViewBag.GetCartSum = session.GetCartSum(products);
            return View(products);
        }

        public ActionResult RemoveCart()
        {
            var session = new SessionManager(HttpContext);
            session.RemoveAllProduct();
            return RedirectToAction(nameof(GetCart));
        }
    }
}