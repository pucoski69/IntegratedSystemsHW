using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Data;
using CinemaApp.Models;



namespace CinemaApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index(MovieGenre movieGenre)
        {
            ViewBag.Genres = Enum.GetValues(typeof(MovieGenre)).Cast<MovieGenre>().ToList();

            return View(await _context.Tickets.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> MovieGenreFilter(MovieGenre movieGenre)
        {
            List<Ticket> tiket;
            ViewBag.Genres = Enum.GetValues(typeof(MovieGenre)).Cast<MovieGenre>().ToList();
            if (movieGenre == MovieGenre.None)
            {
                tiket = await _context.Tickets.ToListAsync();
            }
            else
            {
                tiket = await _context.Tickets.Where(ticket => movieGenre.Equals(ticket.SelectedGenre)).ToListAsync();
            }

            return View(tiket);
        }
        
        [HttpPost]
        public async Task<IActionResult> MovieDateFilter(DateTime FilterDate)
        {
            List<Ticket> tiketi;
            if (FilterDate == null)
            {
                tiketi = await _context.Tickets.ToListAsync();
            }
            else
            {

                tiketi = await _context.Tickets.Where(ticket => DateTime.Compare(ticket.ValidDate.Date, FilterDate.Date) >= 0).ToListAsync();

            }
            return View(tiketi);
        }
        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            var Genre = new Ticket { MoviesGenres = Enum.GetValues(typeof(MovieGenre)).Cast<MovieGenre>().ToList() };
            return View(Genre);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,TicketName,TicketDescription,TicketImage,TicketPrice,SelectedGenre,ValidDate")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Id = Guid.NewGuid();
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FindAsync(id);
            ticket.MoviesGenres= Enum.GetValues(typeof(MovieGenre)).Cast<MovieGenre>().ToList();
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TicketName,TicketDescription,TicketImage,TicketPrice,SelectedGenre,ValidDate")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
