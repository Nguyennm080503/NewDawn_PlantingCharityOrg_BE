using DTOS.News;
using DTOS.PaymentDetail;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.Home
{
    [ApiController]
    public class HomeController : BaseApiController
    {
        private readonly IPaymentTransactionDetailService _transactionDetailService;
        private readonly IPostingNewsService _newsService;

        public HomeController(IPaymentTransactionDetailService transactionDetailService, IPostingNewsService newsService)
        {
            _transactionDetailService = transactionDetailService;
            _newsService = newsService;
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

        [HttpGet("home/news/month")]
        public async Task<ActionResult<IEnumerable<NewsMonthView>>> GetAllNewsEachMonth()
        {
            var postings = await _newsService.GetAllNewsEachMonth();
            return Ok(postings);
        }
    }
}
