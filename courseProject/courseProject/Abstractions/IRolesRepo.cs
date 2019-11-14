using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Models;

namespace courseProject.Abstractions
{
    public interface IRolesRepo
    {
        void Add(Role role);
        void Update(Role role);
        void Delete(Role role);
        Task Save();
        Task<List<Role>> GetAll();
        Task<Role> GetDetail(int? id);
        bool Exist(int id);
    }
}
