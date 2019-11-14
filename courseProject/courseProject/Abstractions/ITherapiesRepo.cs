using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Models;
namespace courseProject.Abstractions
{
    public interface ITherapiesRepo
    {
        void Add(Therapy role);
        void Update(Therapy role);
        void Delete(Therapy role);
        Task Save();
        Task<List<Therapy>> GetAll();
        Task<Therapy> GetDetail(int? id);
        bool Exist(int id);
    }
}
