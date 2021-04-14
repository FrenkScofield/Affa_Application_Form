using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrantApplicationForm.Models.DAL;
using QrantApplicationForm.Models.VM;

namespace QrantApplicationForm.Areas.WebCms.Controllers
{
    [Area("WebCms")]
    // [Route("WebCms/")]
    [Route("WebCms/[controller]/[action]")]

    public class AppealController : Controller
    {
        private readonly MyContext _context;

        public AppealController( MyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _context.ApplicationForms.ToListAsync());
        }

        public async Task<IActionResult> MoreDetailed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            ViewModel viewModel = new ViewModel();

            viewModel.Files = await _context.Files.ToListAsync();

            viewModel.ApplicationForm = await _context.ApplicationForms.FirstOrDefaultAsync(d => d.Id == id);
            

            return View(viewModel);
        }
    }
}
