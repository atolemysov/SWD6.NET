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
    [Authorize(Roles = "Patient")]
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
        public async Task<IActionResult> Details(string UserId, string SurveyId)
        {
            if (UserId == null || SurveyId == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.User_Answers.FindAsync(UserId, SurveyId);
            if (user_Answers == null)
            {
                return NotFound();
            }

            return View(user_Answers);
        }
        // GET: UserAnswers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name");
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Question");
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name", user_Answers.UserId);
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Question", user_Answers.SurveyId);
            return View(user_Answers);
        }

        // GET: UserAnswers/Edit/5
        public async Task<IActionResult> Edit(string UserId, string SurveyId)
        {
            if (UserId == null || SurveyId == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.User_Answers.FindAsync(UserId, SurveyId);
            if (user_Answers == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name", user_Answers.UserId);
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Question", user_Answers.SurveyId);
            return View(user_Answers);
        }

        // POST: UserAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,SurveyId,Answer")] User_Answers user_Answers)
        {

            if (ModelState.IsValid)
            {

                _context.Update(user_Answers);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Full_Name", user_Answers.UserId);
            ViewData["SurveyId"] = new SelectList(_context.Surveys, "Id", "Question", user_Answers.SurveyId);
            return View(user_Answers);
        }

        // GET: UserAnswers/Delete/5
        public async Task<IActionResult> Delete(string UserId, string SurveyId)
        {
            if (UserId == null || SurveyId == null)
            {
                return NotFound();
            }

            var user_Answers = await _context.User_Answers.FindAsync(UserId, SurveyId);
            if (user_Answers == null)
            {
                return NotFound();
            }

            return View(user_Answers);
        }
        // POST: UserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string UserId, string SurveyId)
        {
            var user_Answers = await _context.User_Answers.FindAsync(UserId, SurveyId);
            _context.User_Answers.Remove(user_Answers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_AnswersExists(string id)
        {
            return _context.User_Answers.Any(e => e.UserId == id);
        }
    }
}