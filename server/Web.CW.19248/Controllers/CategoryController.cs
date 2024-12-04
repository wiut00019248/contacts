using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.CW._19248.Dtos;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

namespace Web.CW._19248.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryController(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repository.GetAllAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)        
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repository.CreateAsync(category);
            var newCategoryDto = _mapper.Map<CategoryDto>(category);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategoryDto.Id }, newCategoryDto);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repository.UpdateAsync(category);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _repository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
