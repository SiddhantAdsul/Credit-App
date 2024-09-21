using CountryDemo.Data;
using CountryDemo.Interface;
using CountryDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryDemo.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;
        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Loan country)
        {
            _context.Add(country);
            return Save();
        }

        public bool Delete(Loan country)
        {
            _context.Remove(country);
            return Save();
        }

        public async Task<IEnumerable<Loan>> GetAll()
        {
            return await _context.Loans.ToListAsync();
        }

        

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _context.Loans.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Loan> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Loans.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Loan country)
        {
            _context.Update(country);
            return Save();
        }

        public async Task<IEnumerable<Loan>> GetAllAsync(string searchTerm)
        {
            var query = _context.Loans.AsQueryable();

            if(!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c=> c.Name.Contains(searchTerm));
            }
            return await query.ToListAsync();
        }

        public Task<IEnumerable<Loan>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
