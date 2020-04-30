using AlchemicShop.BLL.Interfaces;
using AlchemicShop.WEB.Models;
using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AlchemicShop.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(
            IAccountService accountService
           )
        {
            _accountService = accountService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel account)
        {
            if (ModelState.IsValid)
            {
                var userAccount = _accountService.GetAccount(account.Login, account.Password);
                if (userAccount != null)
                {
                    FormsAuthentication.SetAuthCookie(userAccount.Login, true);
                    return RedirectToAction("GetProductList", "Product");
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        FlowerModel user = null;
        //        using (SupplyContext db = new SupplyContext())
        //        {
        //            user = db.Flowers.FirstOrDefault(u => u.Name == model.Name);
        //        }
        //        if (user == null)
        //        {
        //            // создаем нового пользователя
        //            using (SupplyContext db = new SupplyContext())
        //            {
        //                db.Flowers.Add(new FlowerModel { Name = model.Name });
        //                db.SaveChanges();

        //                user = db.Flowers.Where(u => u.Name == model.Name).FirstOrDefault();
        //            }
        //            // если пользователь удачно добавлен в бд
        //            if (user != null)
        //            {
        //                FormsAuthentication.SetAuthCookie(model.Name, true);
        //                return RedirectToAction("GetFlowerList", "Flower");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Пользователь с таким логином уже существует");
        //        }
        //    }

        //    return View(model);
        //}
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GetProductList", "Product");
        }
    }
}