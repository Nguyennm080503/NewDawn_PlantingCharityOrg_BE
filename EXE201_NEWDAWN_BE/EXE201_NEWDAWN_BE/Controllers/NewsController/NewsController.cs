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
        private readonly IPostingNewsService _newsService;

        public NewsController(IPostingNewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody]CreateNewsModel createNewsModel)
        {
            var result = await _newsService.CreateNews(createNewsModel);
            if (result == false) {
                return Ok(new ApiResponseStatus(500, "Created Failure"));
            }
            return Ok(new ApiResponseStatus(201, "Created successfully"));  

        }
    }
}
