using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Filters;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System;
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

        public ActionResult CreateCategories()
        {

            return View();
        }

        
        [HttpPost]
        public ActionResult CreateCategories(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                _categoryService.AddCategory(categoryDTO);

                return RedirectToAction(nameof(GetCategoryList));
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult CategoryEdit(int? id)
        {
            var category = _categoryService.GetCategory(id);
            return View(_mapper.Map<CategoryViewModel>(category));
        }

        [HttpPost]
        public ActionResult CategoryEdit(CategoryViewModel categoryView)
        {
            if (ModelState.IsValid)
            {
                var categoryDTO = _mapper.Map<CategoryDTO>(categoryView);
            _categoryService.EditCategory(categoryDTO);

            return RedirectToAction(nameof(GetCategoryList));
            }
            else
            {
                return View(categoryView);
            }
        }

        public ActionResult GetCategoryList()
        {
            var categories = _mapper.Map<List<CategoryViewModel>>(_categoryService.GetCategories().ToList());
            return View(categories);
        }

        public ActionResult CategoryDelete(int? id)
        {
            var category= _categoryService.GetCategory(id);

            return View(_mapper.Map<CategoryViewModel>(category));
        }

        [HttpPost]
        public ActionResult CategoryDelete(int? id, string name)
        {

            _categoryService.DeleteCategory(id);

            return RedirectToAction(nameof(DeleteSuccess), new { deletingCategory = name });
        }

        public ActionResult DeleteSuccess(string deletingCategory)
        {
            ViewBag.Name = deletingCategory;
            return View();
        }

    }
}
