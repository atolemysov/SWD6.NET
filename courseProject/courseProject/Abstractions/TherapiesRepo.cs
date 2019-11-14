using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;
namespace courseProject.Abstractions
{
    public class TherapiesRepo : ITherapiesRepo
    {
        readonly MyContext _context;
        public TherapiesRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(Therapy therapy)
        {
            _context.Add(therapy);
        }

        public void Update(Therapy therapy)
        {
            _context.Update(therapy);
        }

        public void Delete(Therapy therapy)
        {
            _context.Remove(therapy);
        }

        public bool Exist(int id)
        {
            return _context.Therapies.Any(m => m.Id == id);
        }

        public Task<List<Therapy>> GetAll()
        {
            return _context.Therapies.ToListAsync();
        }

        public Task<Therapy> GetDetail(int? id)
        {
            return _context.Therapies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

    }
}
