using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Helpers;
using AlchemicShop.WEB.Models;
using System.Linq;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryServise;

        public CategoryController(ICategoryService service)
        {
            categoryServise = service;
        }
        public ActionResult GetCategories()
        {
            return View(Mapper.CategoryMap(categoryServise.GetCategories().ToList()));
        }

        public ActionResult AddCategories()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategories(CategoryViewModel category)
        {
            var categoryDTO = Mapper.CategoryMap(category);
            categoryServise.AddCategory(categoryDTO);

            return RedirectToAction(nameof(GetCategories));
        }
    }
}