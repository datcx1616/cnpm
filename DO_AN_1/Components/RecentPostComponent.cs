using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_1.Components
{
    [ViewComponent(Name = "RecentPost")]
    public class RecentPostComponent : ViewComponent
    {
        private readonly DataContext _context;
        public RecentPostComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ListfPost = (from p in _context.recentPosts
                             where (p.IsActive == true) && (p.Status == 1)
                             orderby p.Id descending
                             select p ).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", ListfPost));
        }
    }
}
