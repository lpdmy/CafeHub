using CafeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafeHub.MVC.Controllers
{
    [Route("transaction")]
    public class TransactionController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IAccountService _accountService;

        public TransactionController(IPaymentService paymentService, IAccountService accountService)
        {
            _paymentService = paymentService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = await _accountService.GetCurrentUserIdAsync();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var payments = await _paymentService.GetPaymentsByCustomerIdAsync(userId);
            return View("~/Views/Account/Transaction.cshtml", payments);
        }
    }

}
