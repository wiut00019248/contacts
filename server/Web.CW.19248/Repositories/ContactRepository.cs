using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.Models;

namespace Web.CW._19248.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly GeneralDbContext _context;
        public ContactRepository(GeneralDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Contact entity)
        {
            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Contact entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
