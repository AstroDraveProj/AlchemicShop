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


        public ActionResult GetProductList()
        {
            var products = _productService.GetProducts();
            var categories = _categoryService.GetCategories().ToList();
            ViewBag.Categories = _mapper.Map<List<CategoryViewModel>>(categories);

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }


        public async Task<ActionResult> CreateProduct()
        {
            var categories = await Task.Run(() => _categoryService.GetCategories());
            ViewBag.Categories = new SelectList(_mapper.Map<IEnumerable<CategoryViewModel>>(categories), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() => _productService.AddProduct(_mapper.Map<ProductDTO>(product)));

                return RedirectToAction(nameof(GetProductList));
            }
            else return View(product);
        }

        public ActionResult ProductEdit(int? id)
        {
            var product = _productService.GetProduct(id);
            SelectList categories = new SelectList(_mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetCategories()), "Id", "Name");
            ViewBag.Categories = categories;
            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public ActionResult ProductEdit(ProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                var productDTO = _mapper.Map<ProductDTO>(productView);
                _productService.EditProduct(productDTO);

                return RedirectToAction(nameof(GetProductList));
            }
            else
            {
                SelectList categories = new SelectList(_mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetCategories()), "Id", "Name");
                ViewBag.Categories = categories;
                return View(productView);
            }
        }

        public ActionResult ProductDelete(int? id)
        {
            var product = _productService.GetProduct(id);


            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public ActionResult ProductDelete(int? id, string name)
        {
            _productService.Delete(id);

            return RedirectToAction(nameof(DeleteSuccess), new { deletingProduct = name });
        }

        public ActionResult DeleteSuccess(string deletingProduct)
        {
            ViewBag.Name = deletingProduct;
            return View();
        }

    }
}