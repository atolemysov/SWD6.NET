using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;
namespace courseProject.Abstractions
{
    public class UsersRepo : IUsersRepo
    {
        readonly MyContext _context;
        public UsersRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public bool Exist(int id)
        {
            return _context.Users.Any(m => m.Id == id);
        }

        public Task<List<User>> GetAll()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User> GetDetail(int? id)
        {
            return _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<Role> GetRoles()
        {
            return _context.Roles;
        }
    }
}
