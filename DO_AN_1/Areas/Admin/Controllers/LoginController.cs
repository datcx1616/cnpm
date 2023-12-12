using DO_AN_1.Areas.Admin.Models;
using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using DO_AN_1.Utilities;

namespace DO_AN_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            string pw = Functions.MD5Password(user.Password);
            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Invalid UserName or Password!";
                return RedirectToAction("Index", "Login");
            }  
            Functions._Message = String.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = String.IsNullOrEmpty(check.UserName) ? String.Empty : check.UserName;
            Functions._Email = String.IsNullOrEmpty(check.Email) ? String.Empty : check.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}
