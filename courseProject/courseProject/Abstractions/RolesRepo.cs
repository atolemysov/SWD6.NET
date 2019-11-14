using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Abstractions
{
    public class RolesRepo : IRolesRepo
    {
        readonly MyContext _context;
        public RolesRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(Role role)
        {
            _context.Add(role);
        }

        public void Update(Role role)
        {
            _context.Update(role);
        }

        public void Delete(Role role)
        {
            _context.Remove(role);
        }

        public bool Exist(int id)
        {
            return _context.Roles.Any(m => m.Id == id);
        }

        public Task<List<Role>> GetAll()
        {
            return _context.Roles.ToListAsync();
        }

        public Task<Role> GetDetail(int? id)
        {
            return  _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
