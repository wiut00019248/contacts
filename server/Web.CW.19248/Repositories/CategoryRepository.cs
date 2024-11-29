using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.Models;

namespace Web.CW._19248.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly GeneralDbContext _ctx;
        public CategoryRepository(GeneralDbContext context)
        {
            _ctx = context;
        }

        public async Task CreateAsync(Category entity)
        {
            await _ctx.Categories.AddAsync(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _ctx.Categories.FindAsync(id);
            if (category != null)
            {
                _ctx.Categories.Remove(category);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _ctx.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _ctx.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }
    }
}
