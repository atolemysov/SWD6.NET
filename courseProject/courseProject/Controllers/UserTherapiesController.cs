using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using courseProject.Data;
using courseProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace courseProject.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Details(string userId, string therapyId)
        {
            if (userId == null || therapyId == null)
            {
                return NotFound();
            }

            var userTherapy = await _context.User_Therapy.FindAsync(userId, therapyId);
            if (userTherapy == null)
            {
                return NotFound();
            }

            return View(userTherapy);
        }

        
        // GET: UserTherapies/Create
        public IActionResult Create()
        {
            
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name");
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Therapy_Name");
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
            
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name", user_Therapy.UserId);
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Therapy_Name", user_Therapy.TherapyId);
            return View(user_Therapy);
        }

        // GET: UserTherapies/Edit/5
        public async Task<IActionResult> Edit(string userId, string therapyId)
        {
            if (userId == null || therapyId == null)
            {
                return NotFound();
            }

            var user_Therapy = await _context.User_Therapy.FindAsync(userId, therapyId);
            if (user_Therapy == null)
            {
                return NotFound();
            }
            
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name", user_Therapy.UserId);
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Therapy_Name", user_Therapy.TherapyId);
            return View(user_Therapy);
        }

        // POST: UserTherapies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,TherapyId")] User_Therapy user_Therapy)
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
            
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name", user_Therapy.UserId);
            ViewData["TherapyId"] = new SelectList(_context.Therapies, "Id", "Therapy_Name", user_Therapy.TherapyId);
            return View(user_Therapy);
        }


        // GET: UserTherapies/Delete/5
        public async Task<IActionResult> Delete(string userId, string therapyId)
        {
            if (userId == null|| therapyId == null)
            {
                return NotFound();
            }

            var user_Therapy = await _context.User_Therapy.FindAsync(userId, therapyId);
            if (user_Therapy == null)
            {
                return NotFound();
            }

            return View(user_Therapy);
        }

        // POST: UserTherapies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string userId, string therapyId)
        {
            var user_Therapy = await _context.User_Therapy.FindAsync(userId, therapyId);
            _context.User_Therapy.Remove(user_Therapy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_TherapyExists(string id)
        {
            return _context.User_Therapy.Any(e => e.UserId == id);
        }
    }
}
