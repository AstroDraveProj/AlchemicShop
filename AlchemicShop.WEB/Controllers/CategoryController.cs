using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Helpers;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Linq;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryServise;
        private readonly IMapper _mapper; 

        public CategoryController(
            ICategoryService service,
            IMapper mapper)
        {
            _categoryServise = service;
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
            _categoryServise.AddCategory(categoryDTO);

            //return RedirectToAction(nameof(GetCategories));
            return View();
        }
        
        public ActionResult GetCategories()
        {
            return View();
        }
		
		public ActionResult GetCategories()
        {
            var categories = Mapper.Mapping<CategoryDTO, CategoryViewModel>(_categoryService.GetCategories().ToList());
            return View(categories);
        }

        public ActionResult Details(int? id)
        {
            var categoryDto = _categoryService.GetCategory(id);
            var category = _mapper.Mapp<CategoryViewModel>(categoryDto);
            var productsListDtos = _categoryService.GetProducts(categoryDto).ToList();

            var productsList = _mapper.Map<ProductViewModel>(productsListDtos);
                  ViewBag.Products = productsList;

            return View(category);
        }
    }
}