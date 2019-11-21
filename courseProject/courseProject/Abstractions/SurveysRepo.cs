using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;
namespace courseProject.Abstractions
{
    public class SurveysRepo : ISurveysRepo
    {
        readonly MyContext _context;
        public SurveysRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(Survey survey)
        {
            _context.Add(survey);
        }

        public void Update(Survey survey)
        {
            _context.Update(survey);
        }

        public void Delete(Survey survey)
        {
            _context.Remove(survey);
        }

        public bool Exist(string id)
        {
            return _context.Surveys.Any(m => m.Id == id);
        }

        public Task<List<Survey>> GetAll()
        {
            return _context.Surveys.ToListAsync();
        }

        public Task<Survey> GetDetail(string id)
        {
            return _context.Surveys.FirstOrDefaultAsync(m => m.Id == id);
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
