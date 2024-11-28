using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.Models;

namespace Web.CW._19248.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly GeneralDbContext _context;
        public CategoryRepository(GeneralDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category entity)
        {
            _context.CategoryDatabase.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.CategoryDatabase.FindAsync(id);
            if (category != null)
            {
                _context.CategoryDatabase.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.CategoryDatabase.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.CategoryDatabase.FindAsync(id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.CategoryDatabase.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
