using CleanArchitectureScrim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureScrim.Domain.Interface
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAll();
        Task<Blog> GetById(int id);
        Task<Blog> Create(Blog blog);
        Task<int> Update(int id, Blog blog);
        Task<int> Delete(int id);
    }
}
