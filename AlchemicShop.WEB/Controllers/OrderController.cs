﻿using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Managers;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IOrderProductService _orderProductService;
        private readonly IShoppingCartService _scService;
        private readonly IProductService _productService;

        public OrderController(
            IMapper mapper,
            IUserService userService,
            IOrderService orderService,
            IOrderProductService orderProductService,
            IShoppingCartService scService,
            IProductService productService)
        {
            _mapper = mapper;
            _userService = userService;
            _orderService = orderService;
            _orderProductService = orderProductService;
            _scService = scService;
            _productService = productService;
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> GetOrderList()
        {
            ViewBag.Users = _mapper.Map<List<UserViewModel>>(
                await _userService.GetUsers()).ToList();

            return View(_mapper.Map<List<OrderViewModel>>(
                await _orderService.GetOrders()).ToList());
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> DeleteOrder(int? id)
        {
            var order = _mapper.Map<OrderViewModel>(
                await _orderService.GetOrder(id));

            await _orderService.DeleteOrder(
                    _mapper.Map<OrderDTO>(order));
            return RedirectToAction(nameof(GetOrderList));
        }

        [Authorize(Users = "Admin")]
        public async Task<ActionResult> EditOrder(int? id)
        {
            return View(_mapper.Map<OrderViewModel>(
                await _orderService.GetOrder(id)));
        }

        [HttpPost]
        [Authorize(Users = "Admin")]
        public async Task<ActionResult> EditOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.UpdateOrder(
                    _mapper.Map<OrderDTO>(order));
                return RedirectToAction(nameof(GetOrderList));
            }
            return View(order);
        }

        [Authorize(Users = "User")]
        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Users = "User")]
        public async Task<ActionResult> CreateOrder(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddOrder(
                    _mapper.Map<OrderDTO>(
                        new OrderViewModel()
                        {
                            UserId = (int)Session["userLogin"],
                            Status = Models.Status.InTransit,
                            SheduledDate = orderViewModel.SheduledDate
                        }
                        ));

                var session = new SessionManager(HttpContext);
                var products = session.GetOrCreateProductList();

                foreach (var item in products)
                {
                    await _orderProductService.AddOrderProduct(
                       _mapper.Map<OrderProductDTO>(
                           new OrderProductViewModel
                           {
                               OrderId = await _scService.GetMaxOrderIdAsync(),
                               ProductId = item.Id,
                               Amount = item.Amount
                           }
                           ));
                    await _scService.UpdateProductAmount(item.Amount, item.Id);
                }
                session.RemoveAllProduct();
                return RedirectToAction("Index", "Home");
            }
            return View(orderViewModel);
        }

        public async Task<ActionResult> GetOrderDetails(int? id)
        {
            ViewBag.GetOrderSum = await _orderService.GetOrderSum(id);

            ViewBag.GetProductName = _mapper.Map<List<ProductViewModel>>(
                await _productService.GetProducts()).ToList();

            var orderDetails = _mapper.Map<List<OrderProductViewModel>>
                (await _orderProductService.GetOrderProductsId(id)).ToList();

            if(orderDetails.Count>0 && orderDetails != null)
            {
                return View(orderDetails);
            }

            return RedirectToAction(nameof(GetOrderList));
        }

        [Authorize(Users = "User")]
        public async Task<ActionResult> GetUserOrders()
        {
            ViewBag.GetUserName = _mapper.Map<List<UserViewModel>>(
                await _userService.GetUsers()).ToList();

            var userOrders = _mapper.Map<List<OrderViewModel>>
                (await _orderService.GetUserOrderList((int)Session["userLogin"])).ToList();
            
            if (userOrders.Count > 0 && userOrders != null)
            {
                return View(userOrders);
            }
            return RedirectToAction(nameof(EmptyOrderHistory));
        }

        [Authorize(Users = "User")]
        public ActionResult EmptyOrderHistory()
        {
            return View();
        }
    }
}