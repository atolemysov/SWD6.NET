using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Abstractions;
using courseProject.Models;

namespace courseProject.Services
{
    public class TherapiesService
    {
        private readonly ITherapiesRepo _therapyRepo;
        public TherapiesService(ITherapiesRepo therapyRepo)
        {
            _therapyRepo = therapyRepo;
        }

        // GET: Roles
        public async Task<List<Therapy>> GetTherapy()
        {
            return await _therapyRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Therapy> DetailsTherapies(string id)
        {
            return await _therapyRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool TherapyExis(string id)
        {
            return _therapyRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Therapy therapy)
        {
            _therapyRepo.Add(therapy);
            await _therapyRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(Therapy therapy)
        {
            _therapyRepo.Update(therapy);
            await _therapyRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Therapy therapy)
        {
            _therapyRepo.Delete(therapy);
            await _therapyRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }
    }
}
