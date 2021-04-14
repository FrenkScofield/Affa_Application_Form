using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QrantApplicationForm.Areas.WebCms.Controllers
{
    [Area("WebCms")]
    [Route("WebCms/")]
    //[Route("WebCms/[controller]/[action]")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
