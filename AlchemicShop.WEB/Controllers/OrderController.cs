using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Managers;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System;
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

        public OrderController(
            IMapper mapper,
            IUserService userService,
            IOrderService orderService,
            IOrderProductService orderProductService,
            IShoppingCartService scService)
        {
            _mapper = mapper;
            _userService = userService;
            _orderService = orderService;
            _orderProductService = orderProductService;
            _scService = scService;
        }

        public async Task<ActionResult> GetOrderList()
        {
            var orders = await _orderService.GetOrders();
            var users = await _userService.GetUsers();
            ViewBag.Users = _mapper.Map<List<UserViewModel>>(users.ToList());

            return View(_mapper.Map<List<OrderViewModel>>(orders.ToList()));
        }

        public async Task<ActionResult> CreateOrder()
        {
            var order = new OrderViewModel()
            {
                UserId = _scService.GetOrderId(HttpContext.User.Identity.Name),
                Status = Status.Canseled,
                SheduledDate = DateTime.Today
            };


            await _orderService.AddOrder(_mapper.Map<OrderDTO>(order));

            var session = new SessionManager(HttpContext);
            var list = session.GetOrCreateProductList();


            foreach (var item in list)
            {
                var x = new OrderProductViewModel { OrderId = _scService.GetMax(), ProductId = item.Id, Amount = 3 };
                await _orderProductService.AddOrderProduct(
                   _mapper.Map<OrderProductDTO>(x));
            }

            return RedirectToAction(nameof(GetOrderList));
        }
    }
}