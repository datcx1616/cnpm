using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
// Mấy cái ni hiểu cơ bản là: Lưu biến vào trình duyệt nên ở tất cả các trang đề có thể lấy biến đó ra dc. nếu có biến đó thì đã đăng nhập, còn biến đó = null thì chưa đăng nhập.
// Muốn biết ai đăng nhập thì lấy dựa vào ID của người đó. Như trang đăng nhập, sau khi kiểm tra username và password đúng thì lưu id của người đó vào cookie.ok
// Còn Đăng ký cũng vậy, insert vô database rồi lưu ID vừa insert đó vô cookie. Đăng xuất thì xoá cookie đó đi. 

namespace DO_AN_1.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

  

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var userDB = _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            if (userDB == null)
            {
                TempData["message"] = "Tài khoản hoặc mật khẩu không đúng!";
                return View(user);
            }

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserFullName", userDB.FullName ?? "", cookieOptions);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserID", userDB.ID.ToString(), cookieOptions);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Path = "/";
            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserID", user.ID.ToString(), cookieOptions);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserFullName", user.FullName ?? "", cookieOptions);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserFullName");
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserID");
            return RedirectToAction("Index", "Home");
        }

    }
}