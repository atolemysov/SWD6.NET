using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using courseProject.Data;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;
namespace courseProject.Abstractions
{
    public class UserAnswersRepo
    {
        readonly MyContext _context;
        public UserAnswersRepo(MyContext context)
        {
            _context = context;
        }

        public void Add(User_Answers user_answers)
        {
            _context.Add(user_answers);
        }

        public void Update(User_Answers user_answers)
        {
            _context.Update(user_answers);
        }

        public void Delete(User_Answers user_answers)
        {
            _context.Remove(user_answers);
        }

        //public bool Exist(int id)
        //{
        //    return _context.User_Answers.Any(m => m.Id == id);
        //}

        public Task<List<User_Answers>> GetAll()
        {
            return _context.User_Answers.ToListAsync();
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
