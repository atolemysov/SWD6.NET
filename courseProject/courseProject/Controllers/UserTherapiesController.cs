using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using courseProject.Data;
using courseProject.Models;

namespace courseProject.Controllers
{
    public class UserTherapiesController : Controller
    {
        private readonly MyContext _context;

        public UserTherapiesController(MyContext context)
        {
            _context = context;
        }

        // GET: UserTherapies
        public async Task<IActionResult> Index()
        {
            var myContext = _context.User_Therapy.Include(u => u.Therapy).Include(u => u.User);
            return View(await myContext.ToListAsync());
        }

        // GET: UserTherapies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Therapy = await _context.User_Therapy
                .Include(u => u.Therapy)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user_Therapy == null)
            {
                return NotFound();
            }

            return View(user_Therapy);
        }

        // GET: UserTherapies/Create
        public IActionResult Create()
        {
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserTherapies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,TherapyId")] User_Therapy user_Therapy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Therapy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Id", user_Therapy.TherapyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Therapy.UserId);
            return View(user_Therapy);
        }

        // GET: UserTherapies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Therapy = await _context.User_Therapy.FindAsync(id);
            if (user_Therapy == null)
            {
                return NotFound();
            }
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Id", user_Therapy.TherapyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Therapy.UserId);
            return View(user_Therapy);
        }

        // POST: UserTherapies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,TherapyId")] User_Therapy user_Therapy)
        {
            if (id != user_Therapy.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Therapy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_TherapyExists(user_Therapy.UserId))
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
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Id", user_Therapy.TherapyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Therapy.UserId);
            return View(user_Therapy);
        }

        // GET: UserTherapies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Therapy = await _context.User_Therapy
                .Include(u => u.Therapy)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user_Therapy == null)
            {
                return NotFound();
            }

            return View(user_Therapy);
        }

        // POST: UserTherapies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_Therapy = await _context.User_Therapy.FindAsync(id);
            _context.User_Therapy.Remove(user_Therapy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_TherapyExists(int id)
        {
            return _context.User_Therapy.Any(e => e.UserId == id);
        }
    }
}
