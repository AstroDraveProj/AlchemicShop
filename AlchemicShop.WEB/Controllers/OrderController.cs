using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public OrderController(
            IMapper mapper,
            IUserService userService,
            IOrderService orderService)
        {
            _mapper = mapper;
            _userService = userService;
            _orderService = orderService;
        }

        public ActionResult GetOrderList()
        {
            var orders = _orderService.GetOrders();
            var users = _userService.GetUsers().ToList();
            ViewBag.Users = _mapper.Map<List<UserViewModel>>(users);

            return View(_mapper.Map<List<OrderViewModel>>(orders));
        }
    }
}