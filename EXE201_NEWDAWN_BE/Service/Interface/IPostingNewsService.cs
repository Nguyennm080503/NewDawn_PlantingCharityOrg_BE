using DTOS.News;
using Microsoft.AspNetCore.Hosting;

namespace Service.Interface
{
    public interface IPostingNewsService
    {
        Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth();
        Task<ResponseNewsDetail> CreateNews(IWebHostEnvironment webHostEnvironment,CreateNewsModel createNewsModel);
        Task<IEnumerable<ResponseNewsDetail>> GetAllNewsPosting();
    }
}
