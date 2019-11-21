using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using courseProject.Data;
using courseProject.Models;
using courseProject.Services;
using Microsoft.AspNetCore.Authorization;

namespace courseProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SurveysController : Controller
    {
        private readonly SurveysService _surveysService;

        public SurveysController(SurveysService surveysService)
        {
            _surveysService = surveysService;
            
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var surveys = await _surveysService.GetSurvey();
            return View(surveys);
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _surveysService.DetailsSurveys(id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            ViewData["TherapyId"] = new SelectList(_surveysService.getTherapies(), "Id", "Therapy_Name");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Min,Desc1,Max,Desc2,TherapyId")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                
                await _surveysService.AddAndSave(survey);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TherapyId"] = new SelectList(_surveysService.getTherapies(), "Id", "Id", survey.TherapyId);
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _surveysService.DetailsSurveys(id);
            if (survey == null)
            {
                return NotFound();
            }
            ViewData["TherapyId"] = new SelectList(_surveysService.getTherapies(), "Id", "Id", survey.TherapyId);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Question,Min,Desc1,Max,Desc2,TherapyId")] Survey survey)
        {
            if (id != survey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _surveysService.Update(survey);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.Id))
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
            ViewData["TherapyId"] = new SelectList(_surveysService.getTherapies(), "Id", "Id", survey.TherapyId);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survey = await _surveysService.DetailsSurveys(id);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var survey = await _surveysService.DetailsSurveys(id);
            await _surveysService.Delete(survey);
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyExists(string id)
        {
            return _surveysService.SurveyExis(id);
        }
    }
}
