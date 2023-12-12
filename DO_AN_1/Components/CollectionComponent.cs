using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DO_AN_1.Components
{
    [ViewComponent(Name ="Collection")]
    public class CollectionComponent : ViewComponent
    {
        private DataContext _dataContext;
        public CollectionComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke()
        {
            var ListCollection = (from m in _dataContext.collections
                                  select m).Take(10).ToList();
            return View("Default",ListCollection);
        }
    }
}
