using Lab8.Data;
using Lab8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Lab8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext _db;
        public HomeController(ApplicationContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Students.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!Validation.isCorrect(student))
            {
                TempData["notice"] = "Error! Invalid data. Student was not registered.";
                return RedirectToAction("Index");
            }
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Student student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Student student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Student student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Student student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (student != null)
                {
                    _db.Students.Remove(student);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
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
