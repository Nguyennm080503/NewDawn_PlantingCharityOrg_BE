using DTOS.News;
using HostelManagementWebAPI.MessageStatusResponse;
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


        [HttpGet("admin/news/detail/{newsID}")]
        public async Task<IActionResult> GetNewsDetail(int newsID)
        {
            var result = await _newsService.GetNewsDetail(newsID);

            return Ok(result);
        }

        [Authorize(policy: "Admin")]
        [HttpPut("admin/news/delete/{newID}")]
        public async Task<IActionResult> DeleteNews(int newID)
        {
            try
            {
                await _newsService.DeleteNews(newID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Exception when excuting in server!"));
            }

        }
    }
}
