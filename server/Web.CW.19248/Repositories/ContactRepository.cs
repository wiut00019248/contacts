using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.Models;

namespace Web.CW._19248.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly GeneralDbContext _ctx;
        public ContactRepository(GeneralDbContext context)
        {
            _ctx = context;
        }

        public async Task CreateAsync(Contact entity)
        {
            await _ctx.Contacts.AddAsync(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _ctx.Contacts.FindAsync(id);
            if (contact != null)
            {
                _ctx.Contacts.Remove(contact);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _ctx.Contacts.ToListAsync();
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await _ctx.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Contact entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }
    }
}
