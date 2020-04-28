﻿using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ViewBag.Categories = _mapper.Map < List < CategoryViewModel >> (categories);

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        
        public ActionResult Delete(int? id)
        {
            var product = _productService.GetProduct(id);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public ActionResult Delete(int? id, string name)
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