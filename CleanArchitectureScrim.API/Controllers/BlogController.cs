using CleanArchitectureScrim.Application.Services;
using CleanArchitectureScrim.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureScrim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetById(id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var newBlog = await _blogService.Create(blog);
            return CreatedAtAction(nameof(GetById), new { id = newBlog.Id }, newBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            var result = await _blogService.Update(id, blog);

            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _blogService.Delete(id);

            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
