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
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserController(
            IMapper mapper,
            IUserService userService,
            IUserRoleService userRoleService)
        {
            _mapper = mapper;
            _userService = userService;
            _userRoleService = userRoleService;
        }

        public async Task<ActionResult> GetUserList()
        {
            ViewBag.Categories = _mapper.Map<List<UserRoleViewModel>>(
                  (await _userRoleService.GetUserRoles()).ToList());

            return View(_mapper.Map<List<UserViewModel>>
                (await _userService.GetUsers()).ToList());
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUser(_mapper.Map<UserDTO>(user));
            }
            return View(user);
        }

        public async Task<ActionResult> DeleteUser(int? id)
        {
            return View(_mapper.Map<UserViewModel>
                (await _userService.GetUser(id)));
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(int? id, string name)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(DeleteSuccess), new { deleteUser = name });
        }

        public ActionResult DeleteSuccess(string deleteUser)
        {
            ViewBag.Name = deleteUser;
            return View();
        }

        public async Task<ActionResult> EditUser(int? id)
        {
            return View(_mapper.Map<UserViewModel>
                (await _userService.GetUser(id)));
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUser
                    (_mapper.Map<UserDTO>(user));
            }
            return View(user);
        }
    }
}