using DO_AN_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_1.Components
{
    [ViewComponent(Name = "Contact")]
    public class ContactsComponent : ViewComponent
    {
        private DataContext _dataContext;
        public ContactsComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke()
        {
            var list = (from p in _dataContext.contacts
                            //where (p.IsHot == true)
                        select p).Take(10).ToList();
            return View("Default", list);
        }
    }
}
