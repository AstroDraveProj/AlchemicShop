using AlchemicShop.BLL.Interfaces;
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

        public ProductController(
            IMapper mapper,
            IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public ActionResult GetProductList()
        {
            var products = _productService.GetProducts();
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }
    }
}