using DO_AN_1.Components;
using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DO_AN_1.Utilities;
namespace DO_AN_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class categoriesController : Controller
    {
        private readonly DataContext _context;
        public categoriesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var mList = _context.Categories.OrderBy(m => m.id).ToList();
            return View(mList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mm = _context.Categories.Find(id);
            if (mm == null)
            {
                return NotFound();
            }
            return View(mm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleCategories = _context.Categories.Find(id);
            if (deleCategories == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(deleCategories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var mmlist = (from m in _context.Categories
                         select new SelectListItem()
                         {
                             Text = m.name,
                             Value = m.id.ToString()
                         }).ToList();
            mmlist.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnlist = mmlist;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categori Categories)
        {
            if (ModelState.IsValid)
            {
                Categories.ItHot = true;
                _context.Categories.Add(Categories);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Categories);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var m = _context.Categories.Find(id);
            if (m == null)
            {
                return NotFound();
            }

            var mmlist = (from n in _context.Categories
                          select new SelectListItem()
                         {
                             Text = m.name,
                             Value = m.id.ToString()
                         }).ToList();
            mmlist.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mmlist = mmlist;

            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categori mm)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(mm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mm);
        }
    }

}
