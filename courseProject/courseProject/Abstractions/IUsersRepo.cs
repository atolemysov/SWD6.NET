using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Abstractions
{
    public interface IUsersRepo
    {
        void Add(User role);
        void Update(User role);
        void Delete(User role);
        Task Save();
        Task<List<User>> GetAll();
        Task<User> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Role> GetRoles();
    }
}
