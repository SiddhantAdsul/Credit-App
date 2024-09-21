using CountryDemo.Models;

namespace CountryDemo.Interface
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAll();
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan> GetByIdAsync(int id);
        Task<Loan> GetByIdAsyncNoTracking(int id);
        bool Add(Loan loan);
        bool Update(Loan loan);
        bool Delete(Loan loan);
        bool Save();
    }
}
