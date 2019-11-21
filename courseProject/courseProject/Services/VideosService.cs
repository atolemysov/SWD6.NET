using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Abstractions;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Services
{
    public class VideosService
    {
        private readonly IVideosRepo _videoRepo;
        public VideosService(IVideosRepo videoRepo)
        {
            _videoRepo = videoRepo;
        }

        // GET: Roles
        public async Task<List<Video>> GetVideo()
        {
            return await _videoRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Video> DetailsVideos(string id)
        {
            return await _videoRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool VideoExis(string id)
        {
            return _videoRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Video video)
        {
            _videoRepo.Add(video);
            await _videoRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(Video video)
        {
            _videoRepo.Update(video);
            await _videoRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Video video)
        {
            _videoRepo.Delete(video);
            await _videoRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }

        public DbSet<Therapy> getTherapies()
        {
            return _videoRepo.GetTherapies();
        }
    }
}
