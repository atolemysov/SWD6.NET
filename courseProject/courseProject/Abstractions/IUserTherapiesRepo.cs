using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Models;
namespace courseProject.Abstractions
{
    public interface IUserTherapiesRepo
    {
        void Add(User_Therapy role);
        void Update(User_Therapy role);
        void Delete(User_Therapy role);
        Task Save();
        Task<List<User_Therapy>> GetAll();
        Task<User_Therapy> GetDetail(string id);
        bool Exist(string id);
    }
}
