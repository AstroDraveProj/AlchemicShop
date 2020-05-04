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
            var session = new SessionManager(HttpContext);
            var product = await _productService.GetProduct(id);
            session.AddProduct(_mapper.Map<ProductViewModel>(product));
            return RedirectToAction(nameof(GetCart));
        }

        public ActionResult DeleteCartItem(int? id)
        {
            var session = new SessionManager(HttpContext);
            session.DeleteProduct(id);
            return RedirectToAction(nameof(GetCart));
        }

        public ActionResult GetCart()
        {
            var session = new SessionManager(HttpContext);
            return View(session.GetOrCreateProductList());
        }
    }
}