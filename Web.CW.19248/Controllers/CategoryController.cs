using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.CW._19248.DTOs;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.CW._19248.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _catRepo;
        private readonly IMapper _mapper;

        public CategoryController(IRepository<Category> catRepo, IMapper mapper)
        {
            _catRepo = catRepo;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var cat = await _catRepo.GetAllAsync();
            var catDto = _mapper.Map<IEnumerable<CategoryDto>>(cat);
            return Ok(catDto);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var cat = await _catRepo.GetAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            var catDto = _mapper.Map<CategoryDto>(cat);
            return Ok(catDto);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto catDto)        
        {
            var cat = _mapper.Map<Category>(catDto);
            await _catRepo.CreateAsync(cat);
            var newCat = _mapper.Map<CategoryDto>(cat);
            return CreatedAtAction(nameof(GetCategory), new { id = newCat.Id }, newCat);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto catDto)
        {
            if (id != catDto.Id)
            {
                return BadRequest();
            }
            var cat = _mapper.Map<Category>(catDto);
            await _catRepo.UpdateAsync(cat);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var cat = await _catRepo.GetAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            await _catRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
