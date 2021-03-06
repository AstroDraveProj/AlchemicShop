﻿using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
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
            ICategoryService categoryService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [Authorize(Users = "Admin")]
        public ActionResult CreateCategories()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Users = "Admin")]
        public async Task<ActionResult> CreateCategories(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategory(_mapper.Map<CategoryDTO>(category));
                return RedirectToAction(nameof(GetCategoryList));
            }
            else
            {
                return View(category);
            }
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> CategoryEdit(int? id)
        {
            return View(_mapper.Map<CategoryViewModel>
                (await _categoryService.GetCategory(id)));
        }

        [HttpPost]
        [Authorize(Users = "Admin")]
        public async Task<ActionResult> CategoryEdit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.EditCategory(_mapper.Map<CategoryDTO>(category));
                return RedirectToAction(nameof(GetCategoryList));
            }
            else
            {
                return View(category);
            }
        }

        public async Task<ActionResult> GetCategoryList()
        {
            return View(_mapper.Map<List<CategoryViewModel>>
                (await _categoryService.GetCategories()).ToList());
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> CategoryDelete(int? id)
        {
            return View(_mapper.Map<CategoryViewModel>
                (await _categoryService.GetCategory(id)));
        }

        [HttpPost]
        [Authorize(Users = "Admin")]
        public async Task<ActionResult> CategoryDelete(int? id, string name)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(DeleteSuccess), new { deletingCategory = name });
        }

        [Authorize(Users = "Admin")]
        public ActionResult DeleteSuccess(string deletingCategory)
        {
            ViewBag.Name = deletingCategory;
            return View();
        }
    }
}
