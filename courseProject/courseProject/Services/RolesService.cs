using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Abstractions;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Services
{
    public class RolesService
    {
        private readonly IRolesRepo _roleRepo;
        public RolesService(IRolesRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        // GET: Roles
        public async Task<List<Role>> GetRoles()
        {
            return await _roleRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Role> DetailsRoles(int? id)
        {
            return await _roleRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool RolesExis(int id)
        {
            return _roleRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Role role)
        {
            _roleRepo.Add(role);
            await _roleRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(Role role)
        {
            _roleRepo.Update(role);
            await _roleRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Role role)
        {
            _roleRepo.Delete(role);
            await _roleRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }
    }
}
