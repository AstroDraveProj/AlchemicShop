using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public ActionResult GetUserList()
        {
            return View(_mapper.Map<UserViewModel>(_userService.GetUsers()));
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserViewModel user)
        {
            _userService.AddUser(_mapper.Map<UserDTO>(user));
            return View();
        }

        public ActionResult DeleteUser(int? id)
        {
            return View(_userService.GetUser(id));
        }

        [HttpPost]
        public ActionResult DeleteUser(UserViewModel user)
        {
            _userService.DeleteUser(_mapper.Map<UserDTO>(user));
            return View();
        }
    }
}