using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class FolderController : Controller
    {
        public IActionResult GetAll()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot"));
            var folders = directoryInfo.GetDirectories();
            return View(folders);
        }

        public IActionResult Remove(string folderName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName));
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete();
            }
            return RedirectToAction("GetAll", "Folder");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFolder(string folderName)
        {
            
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",folderName));
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            return RedirectToAction("GetAll", "Folder");
        }
    }
}
