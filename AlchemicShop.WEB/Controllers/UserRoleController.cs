using AlchemicShop.BLL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}