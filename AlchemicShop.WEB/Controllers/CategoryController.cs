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
        public ActionResult GetCategories()
        {
            return View();
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

            return RedirectToAction(nameof(GetCategories));
        }
    }
}