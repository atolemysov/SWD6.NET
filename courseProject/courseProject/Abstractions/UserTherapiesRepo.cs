using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;
namespace courseProject.Abstractions
{
    public class UserTherapiesRepo
    {
        readonly MyContext _context;
        public UserTherapiesRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(User_Therapy user_therapy)
        {
            _context.Add(user_therapy);
        }

        public void Update(User_Therapy user_therapy)
        {
            _context.Update(user_therapy);
        }

        public void Delete(User_Therapy user_therapy)
        {
            _context.Remove(user_therapy);
        }

        //public bool Exist(int id)
        //{
        //    return _context.User_Answers.Any(m => m.Id == id);
        //}

        public Task<List<User_Therapy>> GetAll()
        {
            return _context.User_Therapy.ToListAsync();
        }

        //public Task<User_Answers> GetDetail(int? id)
        //{
        //    return _context.User_Answers.FirstOrDefaultAsync(m => m.Id == id);
        //}

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
