using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> GetUserList()
        {
            return View(_mapper.Map<List<UserViewModel>>(await _userService.GetUsers()));
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserViewModel user)
        {
            await _userService.AddUser(_mapper.Map<UserDTO>(user));
            return View();
        }

        public ActionResult DeleteSuccess(string deletingCategory)
        {
            ViewBag.Name = deletingCategory;
            return View();
        }

        public async Task<ActionResult> DeleteUser(int? id)
        {
            var user = await _userService.GetUser(id);
            return View(_mapper.Map<UserViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(int? id, string name)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(DeleteSuccess), new { deletingCategory = name });
        }

        public async Task<ActionResult> EditUser(int? id)
        {
            return View(_mapper.Map<UserViewModel>(await _userService.GetUser(id)));
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel user)
        {
            await _userService.UpdateUser(_mapper.Map<UserDTO>(user));
            return View();
        }
    }
}