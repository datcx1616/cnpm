using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_1.Components
{
    [ViewComponent(Name = "Posts")]
    public class Posts : ViewComponent
    {
        private DataContext _dataContext;
        public Posts(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke()
        {
            var list = (from p in _dataContext.Posts
                        where (p.IsHot == true)
                        select p).Take(3).ToList();
            return View("Default", list);
        }
    }
}
