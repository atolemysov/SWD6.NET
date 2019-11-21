using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using courseProject.Models;
namespace courseProject.Abstractions
{
    public interface IUserAnswersRepo
    {
        void Add(User_Answers role);
        void Update(User_Answers role);
        void Delete(User_Answers role);
        Task Save();
        Task<List<User_Answers>> GetAll();
        Task<User_Answers> GetDetail(string id);
        bool Exist(string id);
    }
}
