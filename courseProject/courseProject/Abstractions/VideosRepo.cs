using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;
namespace courseProject.Abstractions
{
    public class VideosRepo: IVideosRepo
    {
        readonly MyContext _context;
        public VideosRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(Video video)
        {
            _context.Add(video);
        }

        public void Update(Video video)
        {
            _context.Update(video);
        }

        public void Delete(Video video)
        {
            _context.Remove(video);
        }

        public bool Exist(int id)
        {
            return _context.Videos.Any(m => m.Id == id);
        }

        public Task<List<Video>> GetAll()
        {
            return _context.Videos.ToListAsync();
        }

        public Task<Video> GetDetail(int? id)
        {
            return _context.Videos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<Therapy> GetTherapies()
        {
            return _context.Therapies;
        }
    }
}
