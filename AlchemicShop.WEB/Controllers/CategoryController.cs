using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Helpers;
using AlchemicShop.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            ICategoryService service)
        {
            _categoryService = service;
        }

        public ActionResult AddCategories()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategories(CategoryViewModel category)
        {
            var categoryDTO = Mapper.Mapping<CategoryViewModel, CategoryDTO>(category);
            _categoryService.AddCategory(categoryDTO);

            return RedirectToAction(nameof(GetCategories));
        }

        public ActionResult GetCategories()
        {
            var categories = Mapper.Mapping<CategoryDTO, CategoryViewModel>(_categoryService.GetCategories().ToList());
            return View(categories);
        }

        public ActionResult Details(int? id)
        {
            var categoryDto = _categoryService.GetCategory(id);
            var category = Mapper.Mapping<CategoryDTO, CategoryViewModel>(categoryDto);
            var productsListDtos = _categoryService.GetProducts(categoryDto).ToList();

            var productsList = Mapper.Mapping<ProductDTO, ProductViewModel>(productsListDtos);
                  ViewBag.Products = productsList;

            return View(category);
        }
    }
}