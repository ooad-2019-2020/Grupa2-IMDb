using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieHub.Models;
using System.Security.Claims;

namespace MovieHub.Controllers
{

    [Microsoft.AspNetCore.Authorization.Authorize]
    public class WatchlistController : Controller
    {
        private readonly MovieDBContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<RegistrovaniKorisnik> _userManager;

        public WatchlistController(MovieDBContext context, Microsoft.AspNetCore.Identity.UserManager<RegistrovaniKorisnik> userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Watchlist
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var watchlist = await _context.Watchlist.ToListAsync();
            var watchlist = from w in _context.Watchlist select w;
            watchlist = watchlist.Where(w => w.UserID == userId);
            
            return View(await watchlist.AsNoTracking().ToListAsync());
        }

        // GET: Watchlist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /* var watchlist = await _context.Watchlist
                 .FirstOrDefaultAsync(m => m.WatchlistID == id); */

            Watchlist watchlist = await _context.Watchlist
        .Include(w => w.Filmovi)
        .ThenInclude(f => f.Film)
        .AsNoTracking()
        .FirstOrDefaultAsync(w => w.WatchlistID == id);



            if (watchlist == null)
            {
                return NotFound();
            }

            return View(watchlist);
        }

        // GET: Watchlist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Watchlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WatchlistID,Naziv")] Watchlist watchlist)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                watchlist.UserID = userId; 
                _context.Add(watchlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(watchlist);
        }

        // GET: Watchlist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchlist = await _context.Watchlist.FindAsync(id);
            if (watchlist == null)
            {
                return NotFound();
            }
            return View(watchlist);
        }

        // POST: Watchlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WatchlistID,Naziv,UserID")] Watchlist watchlist)
        {
            if (id != watchlist.WatchlistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchlistExists(watchlist.WatchlistID))
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
            return View(watchlist);
        }

        // GET: Watchlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchlist = await _context.Watchlist
                .FirstOrDefaultAsync(m => m.WatchlistID == id);
            if (watchlist == null)
            {
                return NotFound();
            }

            return View(watchlist);
        }

        // POST: Watchlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var watchlist = await _context.Watchlist.FindAsync(id);
            _context.Watchlist.Remove(watchlist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchlistExists(int id)
        {
            return _context.Watchlist.Any(e => e.WatchlistID == id);
        }
    }
}
