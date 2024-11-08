using DataFirstCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataFirstCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodeFirstDbContext context;

        public HomeController(CodeFirstDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await context.Students.ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await context.Students.AddAsync(std);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || context.Students == null)
            {
                return NotFound();
            }
            var data = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        public async  Task<IActionResult> Edit(int? id)
        {
            if(id == null || context.Students == null)
            {
                return NotFound();
            }
            var stddata = await context.Students.FindAsync(id);
            if(stddata == null)
            {
                return NotFound();
            }
            return View(stddata);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(std);
                await context.SaveChangesAsync();   
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Students == null)
            {
                return NotFound();
            }
            var stdData = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await context.Students.FindAsync(id);
            if (stdData != null)
            {
                context.Students.Remove(stdData);
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

