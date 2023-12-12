using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_1.Components
{
    [ViewComponent (Name ="Discount")]
    public class DiscountComponent : ViewComponent
    {
        private DataContext _dataContext;
        public DiscountComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke()
        {
            var List = (from m in _dataContext.discounts
                                  select m).Take(10).ToList();
            return View("Default", List);
        }
    }
}
