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

        public ActionResult CreateCategories()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> CreateCategories(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                await _categoryService.AddCategory(categoryDTO);

                return RedirectToAction(nameof(GetCategoryList));
            }
            else
            {
                return View(category);
            }
        }

        public async Task<ActionResult> CategoryEdit(int? id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(_mapper.Map<CategoryViewModel>(category));
        }

        [HttpPost]
        public async Task<ActionResult> CategoryEdit(CategoryViewModel categoryView)
        {
            if (ModelState.IsValid)
            {
                var categoryDTO = _mapper.Map<CategoryDTO>(categoryView);
                await _categoryService.EditCategory(categoryDTO);

                return RedirectToAction(nameof(GetCategoryList));
            }
            else
            {
                return View(categoryView);
            }
        }

        public async Task<ActionResult> GetCategoryList()
        {
            var categories = await _categoryService.GetCategories();
            return View(_mapper.Map<List<CategoryViewModel>>(categories.ToList()));
        }

        public async Task<ActionResult> CategoryDelete(int? id)
        {
            var category = await _categoryService.GetCategory(id);

            return View(_mapper.Map<CategoryViewModel>(category));
        }

        [HttpPost]
        public async Task<ActionResult> CategoryDelete(int? id, string name)
        {

            await _categoryService.DeleteCategory(id);

            return RedirectToAction(nameof(DeleteSuccess), new { deletingCategory = name });
        }

        public ActionResult DeleteSuccess(string deletingCategory)
        {
            ViewBag.Name = deletingCategory;
            return View();
        }

    }
}
