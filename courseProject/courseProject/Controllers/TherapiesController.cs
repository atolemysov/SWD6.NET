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
    public class TherapiesController : Controller
    {
        private readonly TherapiesService _therapiesService;

        public TherapiesController(TherapiesService therapiesService)
        {
            _therapiesService = therapiesService;
        }

        // GET: Therapies
        public async Task<IActionResult> Index()
        {
            var therapies = await _therapiesService.GetTherapy();
            return View(therapies);
        }

        // GET: Therapies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _therapiesService.DetailsTherapies(id);
            if (therapy == null)
            {
                return NotFound();
            }

            return View(therapy);
        }

        // GET: Therapies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Therapies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Therapy_Name")] Therapy therapy)
        {
            if (ModelState.IsValid)
            {
                
                await _therapiesService.AddAndSave(therapy);
                return RedirectToAction(nameof(Index));
            }
            return View(therapy);
        }

        // GET: Therapies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _therapiesService.DetailsTherapies(id);
            if (therapy == null)
            {
                return NotFound();
            }
            return View(therapy);
        }

        // POST: Therapies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Therapy_Name")] Therapy therapy)
        {
            if (id != therapy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _therapiesService.Update(therapy);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TherapyExists(therapy.Id))
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
            return View(therapy);
        }

        // GET: Therapies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _therapiesService.DetailsTherapies(id);
            if (therapy == null)
            {
                return NotFound();
            }

            return View(therapy);
        }

        // POST: Therapies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var therapy = await _therapiesService.DetailsTherapies(id);
            await _therapiesService.Delete(therapy);
            return RedirectToAction(nameof(Index));
        }

        private bool TherapyExists(string id)
        {
            return _therapiesService.TherapyExis(id);
        }

        public async Task<IActionResult> AddContent(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var therapy = await _therapiesService.DetailsTherapies(id);
            if (therapy == null)
            {
                return NotFound();
            }
            return View(therapy);
        }
    }
}
