using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DO_AN_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class productsController : Controller
    {
        private readonly DataContext _context;
        public productsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var mxList = _context.products.OrderBy(m => m.id).ToList();
            return View(mxList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var m = _context.products.Find(id);
            if (m == null)
            {
                return NotFound();
            }
            return View(m);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleproducts = _context.products.Find(id);
            if (deleproducts == null)
            {
                return NotFound();
            }
            _context.products.Remove(deleproducts);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var mlist = (from m in _context.products
                         select new SelectListItem()
                         {
                             Text = m.name,
                             Value = m.id.ToString()
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
        public IActionResult Create(products products)
        {
            if (ModelState.IsValid)
            {
                products.isActive = true;
                _context.products.Add(products);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var m = _context.products.Find(id);
            if (m == null)
            {
                return NotFound();
            }

            var mlist = (from n in _context.products
                         select new SelectListItem()
                         {
                             Text = m.name,
                             Value = m.id.ToString()
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
        public IActionResult Edit(products m)
        {
            if (ModelState.IsValid)
            {
                _context.products.Update(m);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m);
        }
    }
}
