using Microsoft.AspNetCore.Mvc;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET
                
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Category.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST Method for CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category) 
        {
            if (ModelState.IsValid)
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

    }
}
