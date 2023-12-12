using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DO_AN_1.Components
{
    [ViewComponent( Name ="Blog")]
    public class BlogComponent : ViewComponent
    {
        private DataContext _Context;
        public BlogComponent(DataContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listblog = (from p in _Context.Blogs
                        where (p.IsHot == true)
                        select p).Take(6).ToList();
            return View("Default", listblog);
        }
    }
}
