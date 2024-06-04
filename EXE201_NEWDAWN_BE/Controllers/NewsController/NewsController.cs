using DTOS.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.NewsController
{
    [ApiController]
    public class NewsController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPostingNewsService _newsService;

        public NewsController(IWebHostEnvironment webHostEnvironment, IPostingNewsService newsService)
        {
            _webHostEnvironment = webHostEnvironment;
            _newsService = newsService;
        }

        [Authorize(policy: "Admin")]
        [HttpPost("admin/news/create")]
        public async Task<IActionResult> CreateNews([FromForm]CreateNewsModel createNewsModel)
        {
            var userIdLogIn = GetLoginAccountId();
            var result = await _newsService.CreateNews(_webHostEnvironment, createNewsModel, userIdLogIn);
            
            return Ok(result);  

        }

        [HttpGet("admin/news")]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _newsService.GetAllNewsPosting();

            return Ok(result);
        }


        //[HttpDelete("admin/news")]
        //public async Task<IActionResult> DeleteNews()
        //{
        //    var result = await _newsService.GetAllNewsPosting();

        //    return Ok(result);

        //}
    }
}
