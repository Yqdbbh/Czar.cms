using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotNetCoreCMS.Controllers
{
    public class ContentController : Controller
    {
        private readonly Content contents;

        public ContentController(IOptions<Content> option)
        {
            contents = option.Value;
        }

        public IActionResult Index()
        {
            //var contents = new List<Content>();
            //for(int i = 0; i < 10; i++)
            //{
            //    contents.Add(new Content { Id = i, title = $"{i}的标题", content = $"{i}的内容", status = 1,add_time=DateTime.Now.AddDays(-1) });
            //}

            //return View(new ContentViewModel { Contents=contents});
            return View(new ContentViewModel { Contents = new List<Content> { contents } });
        }
    }
}