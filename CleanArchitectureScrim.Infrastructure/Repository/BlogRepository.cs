using CleanArchitectureScrim.Domain.Entities;
using CleanArchitectureScrim.Domain.Interface;
using CleanArchitectureScrim.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureScrim.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _dbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _dbContext = blogDbContext;
        }


        public async Task<Blog> Create(Blog blog)
        {
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> Delete(int id)
        {
            return await _dbContext.Blogs.Where(model => model.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAll()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _dbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);
        }

        public async Task<int> Update(int id, Blog blog)
        {
            return await _dbContext.Blogs.Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Name, blog.Name)
                .SetProperty(m => m.Description, blog.Description)
                .SetProperty(m => m.Author, blog.Author)
                .SetProperty(m => m.ImageUrl, blog.ImageUrl));
        }
    }
}
