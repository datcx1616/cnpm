using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_1.Components
{
    [ViewComponent(Name = "products")]
    public class productsComponent : ViewComponent
    {
        private DataContext _dataContext;
        public productsComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke()
        {
            var list = (from p in _dataContext.products
                        where (p.isActive == true)
                        select p).Take(10).ToList();
            return View("Default", list);
        }
    }
}
