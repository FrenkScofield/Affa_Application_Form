using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Castle.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QrantApplicationForm.Models;
using QrantApplicationForm.Models.BLL;
using QrantApplicationForm.Models.DAL;
using QrantApplicationForm.Models.Extensiyon;

namespace QrantApplicationForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;
        private readonly IEmailSender _emailSender;
        public IFileUpload _upload;
        public readonly IWebHostEnvironment _env;
        

        public HomeController(ILogger<HomeController> logger,
                                                      MyContext context ,
                                                      IEmailSender emailSender,
                                                      IFileUpload upload,
                                                      IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _emailSender = emailSender;
            _upload = upload;
            _env = env;
        }
    
        public IActionResult Index(int? id )
        {
            if(id == 1)
            {
               ViewBag.Modal = 1;
            }
             else if(id==0)
            {
                ViewBag.Modal = 0;
            }
            else if(id==null)
            {
                ViewBag.Modal = -1;
            }
            return View();
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( ApplicationForm applicationForm, IFormFile file, IFormFile vdfile)
        {

                if (ModelState.IsValid)
                {
                if (file != null)
                    {
                        if (ImagesHelpers.ImageIsValid(file))
                        {
                            applicationForm.ImageCode = await _upload.Create(_env.WebRootPath, file, "img", "cv", applicationForm.ImageCode);
                        }
                    }


                    if (vdfile != null)
                    {
                        //if (ImagesHelpers.ImageIsValid(vdfile))
                        //{
                        applicationForm.VideoCode = await _upload.Create(_env.WebRootPath, vdfile, "img", "video", applicationForm.VideoCode);
                        //}
                    }

                    //save of data

                    var result = await _context.AddAsync(applicationForm);
                    await _context.SaveChangesAsync();

                    //email send

                    await _emailSender.SendEmailAsync(applicationForm.Email, "Dear admin, there is a new application",

                         $"Please log in to the admin panel by clicking on the  " +
                        $"<a href='{HtmlEncoder.Default.Encode($"https://localhost:44399/webcms")}'>" +
                        "LINK." +
                        $"</a>");

                
                 return RedirectToAction("Index", new { id = 1 });
            }

            return RedirectToAction("Index", new { id = 0 });


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
