using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test2.Web.Data;
using Test2.Web.Data.Entity;

namespace Test2.Web.Controllers
{
    public class BookGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookGenres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookGenres.Include(b => b.Book).Include(b => b.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookGenres/Details/5
        public async Task<IActionResult> Details(int? BookID, int? GenreID)
        {
            if (BookID == null || GenreID == null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genre)
                .Where(b => b.GenreID == GenreID)
                .FirstOrDefaultAsync(m => m.BookID == BookID);
            if (bookGenre == null)
            {
                return NotFound();
            }

            return View(bookGenre);
        }

        // GET: BookGenres/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "ID");
            ViewData["GenreID"] = new SelectList(_context.Genre, "ID", "ID");
            return View();
        }

        // POST: BookGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,GenreID")] BookGenre bookGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "ID", bookGenre.BookID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "ID", "ID", bookGenre.GenreID);
            return View(bookGenre);
        }

        // GET: BookGenres/Edit/5
        public async Task<IActionResult> Edit(int? BookID, int? GenreID)
        {
            if (BookID == null || GenreID == null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres.FindAsync(BookID, GenreID);
            if (bookGenre == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "ID", bookGenre.BookID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "ID", "ID", bookGenre.GenreID);
            return View(bookGenre);
        }

        // POST: BookGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int BookID, int GenreID, [Bind("BookID,GenreID")] BookGenre bookGenre)
        {
            if (BookID != bookGenre.BookID || GenreID != bookGenre.GenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookGenreExists(bookGenre.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "ID", bookGenre.BookID);
            ViewData["GenreID"] = new SelectList(_context.Genre, "ID", "ID", bookGenre.GenreID);
            return View(bookGenre);
        }

        // GET: BookGenres/Delete/5
        public async Task<IActionResult> Delete(int? BookID, int? GenreID)
        {
            if (BookID == null || GenreID == null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genre)
                .Where(b => b.GenreID == GenreID)
                .FirstOrDefaultAsync(m => m.BookID == BookID);
            if (bookGenre == null)
            {
                return NotFound();
            }

            return View(bookGenre);
        }

        // POST: BookGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int BookID, int GenreID)
        {
            var bookGenre = await _context.BookGenres.FindAsync(BookID, GenreID);
            if (bookGenre != null)
            {
                _context.BookGenres.Remove(bookGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookGenreExists(int id)
        {
            return _context.BookGenres.Any(e => e.BookID == id);
        }
    }
}
