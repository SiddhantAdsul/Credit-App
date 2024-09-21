using CountryDemo.Data;
using CountryDemo.Interface;
using CountryDemo.Models;
using CountryDemo.Repository;
using CountryDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryDemo.Controllers
{
    public class CountryController : Controller
    {
        private readonly ILoanRepository _loanRepository;
        public CountryController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Loan> loans = await _loanRepository.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                loans = loans.Where(c => c.Name.Contains(searchString)).ToList();
            }
            return View(loans);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLoansViewModel loansVM)
        {
            if (ModelState.IsValid)
            {
                var loans = new Loan
                {
                    Name = loansVM.Name,
                    Amount = loansVM.Amount,
                    Duration = loansVM.Duration,
                    DateApplied = DateTime.Now,
                    Status = Status.Pending
                };
                _loanRepository.Add(loans);
                return RedirectToAction("Index");
            }
            return View(loansVM);
        }
    }
}
