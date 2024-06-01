using DTOS.News;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.NewsController
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPostingNewsService _newsService;

        public NewsController(IWebHostEnvironment webHostEnvironment, IPostingNewsService newsService)
        {
            _webHostEnvironment = webHostEnvironment;
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromForm]CreateNewsModel createNewsModel)
        {
            var result = await _newsService.CreateNews(_webHostEnvironment, createNewsModel);
            
            return Ok(result);  

        }
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var result = await _newsService.GetAllNewsPosting();

            return Ok(result);

        }
    }
}
