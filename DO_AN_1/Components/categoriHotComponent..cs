using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DO_AN_1.Components
{
    [ViewComponent(Name = "categoriHot")]
    public class categoriHot : ViewComponent
    {
        private readonly DataContext _Context;
        public categoriHot(DataContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofpost = (from p in _Context.Categories
                              where (p.isActive == true) && (p.ItHot == true)
                              orderby p.id descending
                              select p).Take(10).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofpost));
        }
    }
}
