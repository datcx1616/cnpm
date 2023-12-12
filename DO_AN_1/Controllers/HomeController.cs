using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace DO_AN_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly DataContext _dataContext;
        private readonly DataContext _Discount;

        public HomeController(ILogger<HomeController> logger, DataContext context, DataContext dataContext, DataContext discount)
        {
            _logger = logger;
            _context = context;
            _dataContext = dataContext;
            _Discount = discount;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult blog()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult shop()
        {
            return View();
        }
        [Route("/blog-{slug}-{id:int}.html", Name = "Details")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blog = _context.Blogs
                .FirstOrDefault(m => (m.Id == id) && (m.IsHot == true));
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
        [Route("/products-{slug}-{id:int}.html", Name = "Detail")]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var products = _dataContext.products
                .FirstOrDefault(m => (m.id == id) && (m.categoryid == null));
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [Route("/add-to-cart-{id:int}", Name = "AddToCart")]
        public JsonResult AddToCart(int id)
        {
            var userID = Request.Cookies["UserID"];
            if (userID == null)
            {
                return Json(new { status = "error", msg = "Vui lòng đăng nhập để thêm vào giỏ hàng!" });
            }
            var product = _context.products.Find(id);
            var productInCart = _context.Carts.Where(c => c.ProductID == id && c.UserID.ToString() == userID).FirstOrDefault();
            if (productInCart == null)
            {
                var productInsert = new Cart();
                productInsert.ProductID = id;
                productInsert.UserID = Int32.Parse(userID);
                productInsert.Quantity = 1;
                productInsert.Price = product.price ?? 0;
                _context.Carts.Add(productInsert);
                _context.SaveChanges();
            }
            else
            {
                productInCart.Quantity++;
                _context.Carts.Update(productInCart);
                _context.SaveChanges();
            }

            return Json(new { status = "success", msg = "Thêm vào giỏ hàng thành công!" });
        }

        [Route("/discount-{slug}-{id:int}.html", Name = "Discount")]
        public IActionResult Discount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var discount = _Discount.discounts
                .FirstOrDefault(m => (m.Id == id) && (m.Price == null));
            //if (Discount == null)
            //{
            //    return NotFound();
            //}
            return View(discount);
        }

        public IActionResult Cart()
        {
            var userid = Request.Cookies["UserID"];
            if (userid == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var carts = _context.CartProducts.Where(c => c.UserID.ToString() == userid).ToList();

            return View(carts);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}