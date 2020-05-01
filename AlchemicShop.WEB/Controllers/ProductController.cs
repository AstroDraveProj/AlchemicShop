using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Filters;
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

        public ProductController(
            IMapper mapper,
            ICategoryService categoryService,
            IProductService productService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
        }


        public async Task<ActionResult> GetProductList()
        {
            var products = await _productService.GetProducts();
            var categories = await _categoryService.GetCategories();
            ViewBag.Categories = _mapper.Map<List<CategoryViewModel>>(categories.ToList());

            return View( _mapper.Map<List<ProductViewModel>>(products.ToList()));
        }


        public async Task<ActionResult> CreateProduct()
        {
            SelectList categories = new SelectList(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetCategories()), "Id", "Name");
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDto = _mapper.Map<ProductDTO>(product);
                await _productService.AddProduct(productDto);

                return RedirectToAction(nameof(GetProductList));
            }
            else
            {
                SelectList categories = new SelectList(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetCategories()), "Id", "Name");
                ViewBag.Categories = categories;
                return View(product);
            }
        }

        public async Task<ActionResult> ProductEdit(int? id)
        {
            var product = await _productService.GetProduct(id);
            var categoryList = await _categoryService.GetCategories();
            SelectList categories = new SelectList(_mapper.Map<IEnumerable<CategoryViewModel>>(categoryList), "Id", "Name");
            ViewBag.Categories = categories;
            return View( _mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public async Task<ActionResult> ProductEdit(ProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                var productDTO = _mapper.Map<ProductDTO>(productView);
                await _productService.EditProduct(productDTO);

                return RedirectToAction(nameof(GetProductList));
            }
            else
            {
                SelectList categories = new SelectList(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.GetCategories()), "Id", "Name");
                ViewBag.Categories = categories;
                return View(productView);
            }
        }

        public async Task<ActionResult> ProductDelete(int? id)
        {
            var product = await _productService.GetProduct(id);
            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public async Task<ActionResult> ProductDelete(int? id, string name)
        {
            await _productService.Delete(id);

            return RedirectToAction(nameof(DeleteSuccess), new { deletingProduct = name });
        }

        public ActionResult DeleteSuccess(string deletingProduct)
        {
            ViewBag.Name = deletingProduct;
            return View();
        }

    }
}