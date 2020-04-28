using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryService service,
            IMapper mapper)
        {
            _categoryService = service;
            _mapper = mapper;
        }

        public ActionResult AddCategories()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategories(CategoryViewModel category)
        {
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            _categoryService.AddCategory(categoryDTO);

            //return RedirectToAction(nameof(GetCategories));
            return View();
        }

        public ActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories().ToList());
            return View(categories);
        }

        public ActionResult Details(int? id)
        {
            //var categoryDto = _categoryService.GetCategory(id);
            //var category = _mapper.Map<CategoryViewModel>(categoryDto);
            //var productsListDtos = _categoryService.GetProducts(categoryDto).ToList();


            //List<ProductViewModel> productsList = _mapper.Map<List<ProductViewModel>>(productsListDtos);
            //ViewBag.Products = productsList;

            return View(/*category*/);
        }
    }
}
