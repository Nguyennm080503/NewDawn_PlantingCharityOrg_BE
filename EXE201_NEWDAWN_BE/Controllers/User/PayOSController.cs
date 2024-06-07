using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.User
{
    [ApiController]
    public class PayOSController : BaseApiController
    {
        private readonly IPayOSService _payOSService;

        public PayOSController(IPayOSService payOSService)
        {
            _payOSService = payOSService;
        }

        [Authorize(policy: "Member")]
        [HttpGet("payos/{quantity}")]
        public async Task<IActionResult> GetLinkPayment(int quantity)
        {
            var urlLink = await _payOSService.CreatePaymentLink(quantity);
            return Ok(urlLink);
        }
    }
}
