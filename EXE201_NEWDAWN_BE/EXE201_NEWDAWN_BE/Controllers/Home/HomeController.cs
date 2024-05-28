using DTOS.PaymentDetail;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.Home
{
    [ApiController]
    public class HomeController : BaseApiController
    {
        private readonly IPaymentTransactionDetailService _transactionDetailService;

        public HomeController(IPaymentTransactionDetailService transactionDetailService)
        {
            _transactionDetailService = transactionDetailService;
        }

        [HttpGet("home/orders/top")]
        public async Task<ActionResult<IEnumerable<TopOrdersView>>> GetTopOrdersViewAsync()
        {
            var order = await _transactionDetailService.GetTopOrdersViewAsync();
            return Ok(order);
        }

        [HttpGet("home/orders/new")]
        public async Task<ActionResult<IEnumerable<NewOrdersView>>> GetNewOrdersViewAsync()
        {
            var order = await _transactionDetailService.GetNewOrdersViewAsync();
            return Ok(order);
        }
    }
}
