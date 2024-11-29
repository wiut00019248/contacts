using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.CW._19248.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repo;

        public CategoryController(IRepository<Category> repo)
        {
            _repo = repo;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var cat = await _repo.GetAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category cat)        
        {
            await _repo.CreateAsync(cat);
            return CreatedAtAction(nameof(GetCategory), new { id = cat.Id }, cat);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category cat)
        {
            await _repo.UpdateAsync(cat);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
