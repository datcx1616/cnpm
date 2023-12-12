using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_1.Components
{
    [ViewComponent(Name = "branch")]
    public class branchComponent : ViewComponent
    {
        private readonly DataContext _context;
        public branchComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Listbranch = (from p in _context.recentPosts
                              where (p.IsActive == true) && (p.Status == 2)
                              orderby p.Id descending
                              select p).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", Listbranch));
        }
    }
}
