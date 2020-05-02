using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace AlchemicShop.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(
            IUserAccountService accountService,
            IUserService userService,
            IMapper mapper
           )
        {
            _accountService = accountService;
            _userService = userService;
            _mapper = mapper;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel account)
        {
            //if (ModelState.IsValid)
            //{
            //    var userAccount = await _accountService.GetAccount(account.Login, account.Password);
            //    if (userAccount != null)
            //    {
            //        FormsAuthentication.SetAuthCookie(userAccount.Login, true);
            //        return RedirectToAction("GetProductList", "Product");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            //    }
            //}
            return View(account);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userAccount = await _userService.GetUser(model.Login);
                //var userAccount = await _accountService.GetUserAsync(model.Login);
                if (userAccount != null)
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
                else
                {
                   // ModelState.AddModelError("", "Поует");
                    await _userService.AddUser(_mapper.Map<UserDTO>(
new UserViewModel { Login = model.Login, Name = model.Name, Password = model.Password, IsAdmin = false }));
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("GetProductList", "Product");
                }
            }
                return View(model);
            }


            public ActionResult Logoff()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("GetProductList", "Product");
            }
        }
    }