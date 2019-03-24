using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreMSSQL.Models;

namespace ASPNETCoreMSSQL.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly DemoContext _context;

        public AttendeesController(DemoContext context)
        {
            _context = context;
        }

        // GET: Attendees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attendee.ToListAsync());
        }

        // GET: Attendees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // GET: Attendees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location")] Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendee);
        }

        // GET: Attendees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendee.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }
            return View(attendee);
        }

        // POST: Attendees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location")] Attendee attendee)
        {
            if (id != attendee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendeeExists(attendee.Id))
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
            return View(attendee);
        }

        // GET: Attendees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // POST: Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendee = await _context.Attendee.FindAsync(id);
            _context.Attendee.Remove(attendee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendeeExists(int id)
        {
            return _context.Attendee.Any(e => e.Id == id);
        }
    }
}
