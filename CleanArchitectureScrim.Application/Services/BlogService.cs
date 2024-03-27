using CleanArchitectureScrim.Domain.Entities;
using CleanArchitectureScrim.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureScrim.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> Create(Blog blog)
        {
           return await _blogRepository.Create(blog);
        }

        public async Task<int> Delete(int id)
        {
            return await _blogRepository.Delete(id);
        }

        public async Task<List<Blog>> GetAll()
        {
            return await _blogRepository.GetAll();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _blogRepository.GetById(id);
        }

        public async Task<int> Update(int id, Blog blog)
        {
            return await _blogRepository.Update(id, blog);
        }
    }
}
