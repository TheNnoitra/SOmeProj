using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.NH.Repositories;
using ITUniver.Calc.DB.Repositories;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository Users { get; set; }

        public AccountController()
        {
            Users = new NHUserRepository();
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if(Users.Check(model.Login, model.Password))
            {
                // поставить отметку о аутентификации
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", "MyDocs");
            }

            ModelState.AddModelError("", "Не удалось выполнить вход");

            return View();
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (Users.GetByName(model.Login) == null)
            {
                var user = new User()
                {
                    Login = model.Login,
                    Name = model.Name,
                    Password = model.Password,
                };
                Users.Save(user);

                // поставить отметку о аутентификации
                FormsAuthentication.SetAuthCookie(model.Login, true);

                return RedirectToAction("Index", "MyDocs");
            }
            else
            {
                ModelState.AddModelError("Login", "Придумайте другое имя. Это уже занято");
            }
            
            return View();
        }

    }
}