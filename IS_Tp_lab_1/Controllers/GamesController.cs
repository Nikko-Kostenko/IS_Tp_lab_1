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
    public class GamesController : Controller
    {
        private readonly GameIndustryContext _context;
        

        public GamesController(GameIndustryContext context)
        {
            _context = context;
           

        }

        // GET: Games
        public async Task<IActionResult> Index(int? id, string? name, int? studioId, string? studioName, int? genreId)
        {
             

            ViewBag.StudioId = studioId;
            ViewBag.StudioName = studioName;
            ViewBag.PlatformId = id;
            ViewBag.PlatformName = name;
            ViewBag.GenreId = genreId;
           
            
            


            if (id != null)
            {
                if (genreId == null)
                {
                    return View(await _context.Games.Where(g => g.PlatformId == id).Include(g => g.GameStudio)
                        .Include(g => g.Genre).Include(g => g.Platform).ToListAsync());
                }
                else
                {
                    return View(await _context.Games.Where(g => g.GenreId == genreId).Where(g => g.PlatformId == id).Include(g => g.GameStudio)
                        .Include(g => g.Genre).Include(g => g.Platform).ToListAsync());
                }
            }
            else if (studioId != null)
            {
                if (genreId == null)
                {
                    return View(await _context.Games.Where(g => g.GameStudioId == studioId).Include(g => g.GameStudio)
                        .Include(g => g.Genre).Include(g => g.Platform).ToListAsync());
                }
                else
                {
                   
                    return View(await _context.Games.Where(g => g.GenreId == genreId).Where(g => g.GameStudioId == studioId).Include(g => g.GameStudio)
                        .Include(g => g.Genre).Include(g => g.Platform).ToListAsync());
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.GameStudio)
                .Include(g => g.Genre)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create(int? PlatformId, int? StudioId)
        {
            
            if (PlatformId == null)
            {
                ViewBag.CheckIndex = null;
                ViewBag.StudioId = StudioId;
                ViewBag.StudioName = _context.GameStudios.Where(c => c.Id == StudioId).FirstOrDefault().Name;
                ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Name");
                ViewData["GameStudioId"] = StudioId;
            }
            else
            {   ViewBag.CheckIndex = 1;               
                ViewBag.PlatfromId =  PlatformId;       
                ViewBag.PlatformName = _context.Platforms.Where(c => c.Id == PlatformId).FirstOrDefault().Name;
                ViewData["PlatformId"] = PlatformId;
                ViewData["GameStudioId"] = new SelectList(_context.GameStudios, "Id", "Name");
            }
            
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? PlatformId, int StudioId, [Bind("Id,Name,GenreId,PlatformId,GameStudioId,Info")] Game game)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (PlatformId == null)
            {
                ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Name", game.PlatformId);
                ViewData["GameStudioId"] = StudioId;
            }
            else
            {
                ViewData["PlatformId"] = PlatformId;
                ViewData["GameStudioId"] = new SelectList(_context.GameStudios, "Id", "Name", game.GameStudioId);
            }
            //ViewData["GameStudioId"] = new SelectList(_context.GameStudios, "Id", "Name", game.GameStudioId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", game.GenreId);
           // ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Name", game.PlatformId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["GameStudioId"] = new SelectList(_context.GameStudios, "Id", "Name", game.GameStudioId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", game.GenreId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Name", game.PlatformId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GenreId,PlatformId,GameStudioId,Info")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            ViewData["GameStudioId"] = new SelectList(_context.GameStudios, "Id", "Name", game.GameStudioId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", game.GenreId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Name", game.PlatformId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.GameStudio)
                .Include(g => g.Genre)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
