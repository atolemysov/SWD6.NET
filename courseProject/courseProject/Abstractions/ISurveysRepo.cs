using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Abstractions
{
    public interface ISurveysRepo
    {
        void Add(Survey role);
        void Update(Survey role);
        void Delete(Survey role);
        Task Save();
        Task<List<Survey>> GetAll();
        Task<Survey> GetDetail(string id);
        bool Exist(string id);
        DbSet<Therapy> GetTherapies();
    }
}
