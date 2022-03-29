using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.ViewComponents
{
    public class NewsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var lists = NewsContext.News;
            return View(lists);
        }
    }
}
