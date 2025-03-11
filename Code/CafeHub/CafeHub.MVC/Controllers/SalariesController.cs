using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;
using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;

namespace CafeHub.MVC.Controllers
{
    public class SalariesController : Controller
    {
        private readonly ISalaryService _salaryService;

        public SalariesController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        public async Task<IActionResult> Index(int? staffId)
        {
            List<Salary> salaries;

            if (staffId.HasValue)
            {
                salaries = await _salaryService.GetSalariesByStaffIdAsync(staffId.Value);
            }
            else
            {
                salaries = await _salaryService.GetAllSalariesAsync();
            }

            return View(salaries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffId,Amount,PaymentData")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                await _salaryService.CreateSalaryAsync(salary);
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var salary = await _salaryService.GetSalariesByStaffIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StaffId,Amount,PaymentData")] Salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _salaryService.ModifySalaryAsync(salary);
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var salary = await _salaryService.RemoveSalaryAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
