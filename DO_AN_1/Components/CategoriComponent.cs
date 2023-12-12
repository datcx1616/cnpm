using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_1.Components
{
    [ViewComponent(Name = "Categori")]
    public class CategoriComponent : ViewComponent
    {
        private readonly DataContext _Context;
        public CategoriComponent(DataContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofpost = (from p in _Context.Categories
                              where (p.isActive == true)
                              orderby p.id descending
                              select p).Take(10).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofpost));
        }
    }
}
