using Microsoft.AspNetCore.Mvc;
using DO_AN_1.Utilities;
namespace DO_AN_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._UserName = String.Empty;
            Functions._Email = String.Empty;
            Functions._Message = String.Empty;
            Functions._MessageEmail = String.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}
