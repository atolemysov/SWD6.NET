using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Abstractions
{
    public interface IVideosRepo
    {
        void Add(Video role);
        void Update(Video role);
        void Delete(Video role);
        Task Save();
        Task<List<Video>> GetAll();
        Task<Video> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Therapy> GetTherapies();
    }
}
