using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class FileController : Controller
    {
        public IActionResult GetAll()
        {
            DirectoryInfo directoryInfo =
                new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));
            var files = directoryInfo.GetFiles();
            return View(files);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(string fileName)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName));
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }
            return RedirectToAction("GetAll", "File");
        }

        [HttpGet]
        public IActionResult CreateTextData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTextData(string fileName,string text)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName));
            StreamWriter streamWriter= fileInfo.CreateText();
            streamWriter.Write(text);
            streamWriter.Close();
            return RedirectToAction("GetAll", "File");
        }

        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FileUpload(IFormFile formFile)
        {
            var extension = Path.GetExtension(formFile.FileName);
            var path = Directory.GetCurrentDirectory()+"/wwwroot/"+Guid.NewGuid()+extension;
            FileStream fileStream = new FileStream(path,FileMode.Create);
            formFile.CopyTo(fileStream);
            return RedirectToAction("GetAll", "File");

        }

        public IActionResult Remove(string fileName)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",fileName));
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            return RedirectToAction("GetAll", "File");
        }
    }
}
