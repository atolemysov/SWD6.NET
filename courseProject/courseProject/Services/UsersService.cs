using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Abstractions;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Services
{
    public class UsersService
    {
        private readonly IUsersRepo _userRepo;
        public UsersService(IUsersRepo userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: Roles
        public async Task<List<User>> GetUser()
        {
            return await _userRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<User> DetailsUsers(int? id)
        {
            return await _userRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool UserExis(int id)
        {
            return _userRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(User user)
        {
            _userRepo.Add(user);
            await _userRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(User user)
        {
            _userRepo.Update(user);
            await _userRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(User user)
        {
            _userRepo.Delete(user);
            await _userRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }

        public DbSet<Role> getRoles()
        {
            return _userRepo.GetRoles();
        }
    }
}
