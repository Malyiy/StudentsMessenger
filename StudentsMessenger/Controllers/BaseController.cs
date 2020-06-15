using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsMessenger.Models;
using Microsoft.Extensions.Logging;

namespace StudentsMessenger.Controllers
{
    public class BaseController : Controller
    {
        private readonly BaseContext _context;
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public BaseController(
            UserManager<Student> userManager,
            SignInManager<Student> signInManager,
            ILogger<HomeController> logger,
            BaseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }



        public async Task<ActionResult> Index()
        {
            Student user = await _userManager.GetUserAsync(User);
            if (user != null)
                return View(await _context.Works.ToListAsync());
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,File")] UploadViewModel form)
        {
            if (ModelState.IsValid)
            {
                Work work = new Work { Titlework = form.Name, Date = DateTime.Now };
                byte[] bytes = null;
                using (var fileStream = form.File.OpenReadStream())
                using (var memStream = new MemoryStream())
                {
                    fileStream.CopyTo(memStream);
                    bytes = memStream.ToArray();
                }
                work.FileBytes = bytes;
                work.Titlework = form.File.FileName;
                work.FileType = form.File.ContentType;
                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }
        public async Task<IActionResult> FileDownload(int id)
        {
            var work = await _context.Works
                .FirstOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }
            return File( work.FileBytes, work.Titlework , work.FileType);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
       

    }
}