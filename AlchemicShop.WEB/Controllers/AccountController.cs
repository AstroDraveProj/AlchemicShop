using AlchemicShop.BLL.DTO;
using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace AlchemicShop.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IMapper mapper
           )
        {
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
            if (ModelState.IsValid)
            {
                var userAccount = await _userService.GetUser(account.Login, account.Password);
                if (userAccount != null)
                {
                    Session["userLogin"] = userAccount.Id;
                    FormsAuthentication.SetAuthCookie(userAccount.Role.ToString(), true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
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
                if (userAccount != null)
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
                else
                {
                    await _userService.AddUser(_mapper.Map<UserDTO>(
                    new UserViewModel { Login = model.Login, Name = model.Name, Password = model.Password, Role = Models.Role.User }));
                    FormsAuthentication.SetAuthCookie(Models.Role.User.ToString(), true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}