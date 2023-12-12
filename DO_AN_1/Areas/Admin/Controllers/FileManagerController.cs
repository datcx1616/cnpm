using Microsoft.AspNetCore.Mvc;
using DO_AN_1.Utilities;
namespace DO_AN_1.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Route("/Admin/file-manager")]
    //public class FileManagerController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    [Area("Admin")]
    [Route("/Admin/file-manager")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
