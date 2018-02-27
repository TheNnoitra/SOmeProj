using ITUniver.Calc.DB.NH.Repositories;
using ITUniver.Calc.DB.Repositories;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private IUserRepository Users { get; set; }

        public ManageController()
        {
            Users = new NHUserRepository();
        }

        // GET: Manage
        public ActionResult Index()
        {
            var users = Users.GetAll();
            return View(users);
        }

        public ActionResult Delete(long id)
        {
            Users.Delete(id);
            return RedirectToAction("Index");
        }

    }
}