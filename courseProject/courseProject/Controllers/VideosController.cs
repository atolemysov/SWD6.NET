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
    public class VideosController : Controller
    {
        private readonly VideosService _videosService;

        public VideosController(VideosService videosService)
        {
            _videosService = videosService;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var videos = await _videosService.GetVideo();
            return View(videos);
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _videosService.DetailsVideos(id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            ViewData["TherapyId"] = new SelectList(_videosService.getTherapies(), "Id", "Therapy_Name");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Desc,Url_Video,TherapyId")] Video video)
        {
            if (ModelState.IsValid)
            {

                await _videosService.AddAndSave(video);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TherapyId"] = new SelectList(_videosService.getTherapies(), "Id", "Id", video.TherapyId);
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _videosService.DetailsVideos(id);
            if (video == null)
            {
                return NotFound();
            }
            ViewData["TherapyId"] = new SelectList(_videosService.getTherapies(), "Id", "Id", video.TherapyId);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Desc,Url_Video,TherapyId")] Video video)
        {
            if (id != video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _videosService.Update(video);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.Id))
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
            ViewData["TherapyId"] = new SelectList(_videosService.getTherapies(), "Id", "Id", video.TherapyId);
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _videosService.DetailsVideos(id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var video = await _videosService.DetailsVideos(id);
            await _videosService.Delete(video);
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(string id)
        {
            return _videosService.VideoExis(id);
        }
    }
}
