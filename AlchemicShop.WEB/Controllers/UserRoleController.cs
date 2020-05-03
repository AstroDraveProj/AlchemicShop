using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlchemicShop.WEB.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(
            IUserRoleService userRoleservice,
            IMapper mapper)
        {
            _userRoleService = userRoleservice;
            _mapper = mapper;
        }

        public async Task<ActionResult> GetUserRoleList()
        {
            return View(_mapper.Map<List<UserRoleViewModel>>(
                await _userRoleService.GetUserRoles()));
        }
    }
}