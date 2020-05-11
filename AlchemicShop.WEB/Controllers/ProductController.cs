using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISortService _sortService;

        public ProductController(
            IMapper mapper,
            ICategoryService categoryService,
            IProductService productService,
            ISortService sortService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
            _sortService = sortService;
        }

        public async Task<ActionResult> GetProductList(string sortOrder)
        {
            ViewBag.SortPrice = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";

            ViewBag.SortAmount = String.IsNullOrEmpty(sortOrder) ? "amount_desc" : "";

            var product = _mapper.Map<List<ProductViewModel>>
              (await _sortService.SortProductPrice(sortOrder));

            ViewBag.Categories = _mapper.Map<List<CategoryViewModel>>(
                (await _categoryService.GetCategories()).ToList());

            return View(product);
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> CreateProduct()
        {
            ViewBag.Categories = new SelectList(
                _mapper.Map<IEnumerable<CategoryViewModel>>
                (await _categoryService.GetCategories()), "Id", "Name");

            return View();
        }


        [HttpPost]
        [Authorize(Users = "Admin")]
        public async Task<ActionResult> CreateProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProduct(_mapper.Map<ProductDTO>(product));
                return RedirectToAction(nameof(GetProductList));
            }
            else
            {
                ViewBag.Categories = new SelectList(
                    _mapper.Map<IEnumerable<CategoryViewModel>>
                    (await _categoryService.GetCategories()), "Id", "Name");

                return View(product);
            }
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> ProductEdit(int? id)
        {
            ViewBag.Categories = new SelectList(
            _mapper.Map<IEnumerable<CategoryViewModel>>
            (await _categoryService.GetCategories()), "Id", "Name");

            return View(_mapper.Map<ProductViewModel>
                (await _productService.GetProduct(id)));
        }

        [HttpPost]
        [Authorize(Users = "Admin")]
        public async Task<ActionResult> ProductEdit(ProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                await _productService.EditProduct(_mapper.Map<ProductDTO>(productView));
                return RedirectToAction(nameof(GetProductList));
            }
            else
            {
                ViewBag.Categories = new SelectList(
                    _mapper.Map<IEnumerable<CategoryViewModel>>
                    (await _categoryService.GetCategories()), "Id", "Name");
                return View(productView);
            }
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> ProductDelete(int? id)
        {
            return View(_mapper.Map<ProductViewModel>
                (await _productService.GetProduct(id)));
        }

        [HttpPost]
        [Authorize(Users = "Admin")]
        public async Task<ActionResult> ProductDelete(int? id, string name)
        {
            await _productService.Delete(id);
            return RedirectToAction(nameof(DeleteSuccess), new { deletingProduct = name });
        }

        [Authorize(Users = "Admin")]
        public ActionResult DeleteSuccess(string deletingProduct)
        {
            ViewBag.Name = deletingProduct;
            return View();
        }
    }
}