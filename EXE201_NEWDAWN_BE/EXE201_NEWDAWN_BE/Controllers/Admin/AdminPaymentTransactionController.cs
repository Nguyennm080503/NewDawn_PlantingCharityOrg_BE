using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.Admin
{
    [ApiController]
    public class AdminPaymentTransactionController : BaseApiController
    {
        private readonly IPaymentTransactionService _paymentTransactionService;
        
        public AdminPaymentTransactionController(IPaymentTransactionService paymentTransactionService)
        {
            _paymentTransactionService = paymentTransactionService;
        }

        [Authorize(policy: "Admin")]
        [HttpGet("admin/transactions/newest")]
        public async Task<ActionResult> GetTop4Transactions()
        {
            var transactions = await _paymentTransactionService.Top4Transactions();
            if (transactions != null)
            {
                return Ok(transactions);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }

        [Authorize(policy: "Admin")]
        [HttpGet("admin/transactions")]
        public async Task<ActionResult> GetAllTransactions()
        {
            var transactions = await _paymentTransactionService.GetAllTransactions();
            if (transactions != null)
            {
                return Ok(transactions);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }
    }
}
