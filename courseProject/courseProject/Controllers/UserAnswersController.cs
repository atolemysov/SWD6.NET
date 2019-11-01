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
    public class UserAnswersController : Controller
    {
        private readonly MyContext _context;

        public UserAnswersController(MyContext context)
        {
            _context = context;
        }

        // GET: UserAnswers
        public async Task<IActionResult> Index()
        {
            var myContext = _context.User_Answers.Include(u => u.Survey).Include(u => u.User);
            return View(await myContext.ToListAsync());
        }

        // GET: UserAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.User_Answers
                .Include(u => u.Survey)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user_Answers == null)
            {
                return NotFound();
            }

            return View(user_Answers);
        }

        // GET: UserAnswers/Create
        public IActionResult Create()
        {
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,SurveyId,Answer")] User_Answers user_Answers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Answers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Id", user_Answers.SurveyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Answers.UserId);
            return View(user_Answers);
        }

        // GET: UserAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.User_Answers.FindAsync(id);
            if (user_Answers == null)
            {
                return NotFound();
            }
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Id", user_Answers.SurveyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Answers.UserId);
            return View(user_Answers);
        }

        // POST: UserAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,SurveyId,Answer")] User_Answers user_Answers)
        {
            if (id != user_Answers.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Answers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_AnswersExists(user_Answers.UserId))
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
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Id", user_Answers.SurveyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Answers.UserId);
            return View(user_Answers);
        }

        // GET: UserAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.User_Answers
                .Include(u => u.Survey)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user_Answers == null)
            {
                return NotFound();
            }

            return View(user_Answers);
        }

        // POST: UserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_Answers = await _context.User_Answers.FindAsync(id);
            _context.User_Answers.Remove(user_Answers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_AnswersExists(int id)
        {
            return _context.User_Answers.Any(e => e.UserId == id);
        }
    }
}
