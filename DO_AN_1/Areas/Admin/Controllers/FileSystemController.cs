﻿using elFinder.NetCore.Drivers.FileSystem;
using elFinder.NetCore;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DO_AN_1.Utilities;
namespace DO_AN_1.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Route("/Admin/el-finder-file-system")]
    //public class FileSytemController : Controller
    //{
    //    readonly IWebHostEnvironment _env;
    //    public FileSytemController(IWebHostEnvironment env) => _env = env;
    //    [Route("connector")]
    //    public async Task<IActionResult> connector()
    //    {
    //        var connector = GetConnector();
    //        var result = await connector.ProcessAsync(Request);
    //        if (result is JsonResult)
    //        {
    //            var json = result as JsonResult;
    //            return Content(JsonSerializer.Serialize(json.Value), json.ContentType);
    //        }    
    //        else
    //        {
    //            return Json(result);
    //        }    
    //    }
    //    [Route("thumb/{hash}")]
    //    public async Task<IActionResult> Thumbs(string hash)
    //    {
    //        var connector = GetConnector();
    //        return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
    //    }
    //    private Connector GetConnector()
    //    {
    //        string pathroot = "files";
    //        var driver = new FileSystemDriver();
    //        string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
    //        var uri  = new Uri(absoluteUrl);
    //        string rootDirectory = Path.Combine(_env.WebRootPath, pathroot);
    //        string url = $"/{pathroot}";
    //        string urlthumb = $"{uri.Scheme}://Admin/el-finder-file-system/thumb/";
    //        var root = new RootVolume(rootDirectory, url, urlthumb)
    //        {
    //            IsReadOnly = false,
    //            IsLocked = false,
    //            Alias = "Files",
    //            ThumbnailSize = 100,
    //        };
    //        driver.AddRoot(root);
    //        return new Connector(driver)
    //        {
    //            MimeDetect = MimeDetectOption.Internal
    //        };
    //    }
    //}
    [Area("Admin")]
    [Route("/Admin/el-finder-file-system")]
    public class FileSystemController : Controller
    {

        readonly IWebHostEnvironment _env;
        public FileSystemController(IWebHostEnvironment env) => _env = env;
        [Route("connector")]
        public async Task<IActionResult> Connector()
        {
            var connector = GetConnector();
            var result = await connector.ProcessAsync(Request);
            if (result is JsonResult)
            {
                var json = result as JsonResult;
                return Content(JsonSerializer.Serialize(json.Value), json.ContentType);
            }
            else
            {
                return Json(result);
            }
        }

        // Địa chỉ để truy vấn thumbnail
        // /el-finder-file-system/thumb
        [Route("thumb/{hash}")]
        public async Task<IActionResult> Thumbs(string hash)
        {
            var connector = GetConnector();
            return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
        }

        private Connector GetConnector()
        {
            // Thư mục gốc lưu trữ là wwwwroot/files (đảm bảo có tạo thư mục này)
            string pathroot = "files";

            var driver = new FileSystemDriver();

            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            // .. ... wwww/files
            string rootDirectory = Path.Combine(_env.WebRootPath, pathroot);

            string url = $"/{pathroot}/";
            string urlthumb = $"{uri.Scheme}:/Admin/el-finder-file-system/thumb/";


            var root = new RootVolume(rootDirectory, url, urlthumb)
            {
                //IsReadOnly = !User.IsInRole("Administrators")
                IsReadOnly = false, // Can be readonly according to user's membership permission
                IsLocked = false, // If locked, files and directories cannot be deleted, renamed or moved
                Alias = "Files", // Beautiful name given to the root/home folder
                //MaxUploadSizeInKb = 2048, // Limit imposed to user uploaded file <= 2048 KB
                //LockedFolders = new List<string>(new string[] { "Folder1" }
                ThumbnailSize = 100,
            };


            driver.AddRoot(root);

            return new Connector(driver)
            {
                // This allows support for the "onlyMimes" option on the client.
                MimeDetect = MimeDetectOption.Internal
            };
        }
    }
}