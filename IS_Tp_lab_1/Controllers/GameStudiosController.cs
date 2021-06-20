using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS_Tp_lab_1;

namespace IS_Tp_lab_1.Controllers
{
    public class GameStudiosController : Controller
    {
        private readonly GameIndustryContext _context;

        public GameStudiosController(GameIndustryContext context)
        {
            _context = context;
        }

        // GET: GameStudios
        public async Task<IActionResult> Index()
        {
            var gameIndustryContext = _context.GameStudios.Include(g => g.Country);
            return View(await gameIndustryContext.ToListAsync());
        }

        // GET: GameStudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStudio = await _context.GameStudios
                .Include(g => g.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameStudio == null)
            {
                return NotFound();
            }

            return View(gameStudio);
        }

        // GET: GameStudios/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: GameStudios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Info,CountryId")] GameStudio gameStudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameStudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", gameStudio.CountryId);
            return View(gameStudio);
        }

        // GET: GameStudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStudio = await _context.GameStudios.FindAsync(id);
            if (gameStudio == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", gameStudio.CountryId);
            return View(gameStudio);
        }

        // POST: GameStudios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Info,CountryId")] GameStudio gameStudio)
        {
            if (id != gameStudio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameStudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameStudioExists(gameStudio.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", gameStudio.CountryId);
            return View(gameStudio);
        }

        // GET: GameStudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameStudio = await _context.GameStudios
                .Include(g => g.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameStudio == null)
            {
                return NotFound();
            }

            return View(gameStudio);
        }

        // POST: GameStudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameStudio = await _context.GameStudios.FindAsync(id);
            _context.GameStudios.Remove(gameStudio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameStudioExists(int id)
        {
            return _context.GameStudios.Any(e => e.Id == id);
        }
    }
}
