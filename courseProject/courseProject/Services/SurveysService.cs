using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Abstractions;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Services
{
    public class SurveysService
    {
        private readonly ISurveysRepo _surveyRepo;
        public SurveysService(ISurveysRepo surveyRepo)
        {
            _surveyRepo = surveyRepo;
        }

        // GET: Roles
        public async Task<List<Survey>> GetSurvey()
        {
            return await _surveyRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Survey> DetailsSurveys(int? id)
        {
            return await _surveyRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool SurveyExis(int id)
        {
            return _surveyRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Survey survey)
        {
            _surveyRepo.Add(survey);
            await _surveyRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(Survey survey)
        {
            _surveyRepo.Update(survey);
            await _surveyRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Survey survey)
        {
            _surveyRepo.Delete(survey);
            await _surveyRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }

        public DbSet<Therapy> getTherapies()
        {
            return _surveyRepo.GetTherapies();
        }
    }
}
