using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DO_AN_1.Utilities;
namespace DO_AN_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            var mList = _context.Blogs.OrderBy(m => m.Id).ToList();
            return View(mList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var m = _context.Blogs.Find(id);
            if (m == null)
            {
                return NotFound();
            }
            return View(m);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleBlog = _context.Blogs.Find(id);
            if (deleBlog == null)
            {
                return NotFound();
            }
            _context.Blogs.Remove(deleBlog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var mlist = (from m in _context.Blogs
                          select new SelectListItem()
                          {
                              Text = m.Title,
                              Value = m.Id.ToString()
                          }).ToList();
            mlist.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnlist = mlist;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog Blog)
        {
            if (ModelState.IsValid)
            {
                Blog.IsHot = true;
                _context.Blogs.Add(Blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Blog);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var m = _context.Blogs.Find(id);
            if (m == null)
            {
                return NotFound();
            }

            var mlist = (from n in _context.Blogs
                          select new SelectListItem()
                          {
                              Text = m.Title,
                              Value = m.Id.ToString()
                          }).ToList();
            mlist.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mlist = mlist;

            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog m)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Update(m);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m);
        }
    }
}
