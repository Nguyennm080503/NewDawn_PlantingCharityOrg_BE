using DTOS.News;
using Microsoft.AspNetCore.Hosting;

namespace Service.Interface
{
    public interface IPostingNewsService
    {
        Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth();
        Task<ResponseNewsDetail> CreateNews(IWebHostEnvironment webHostEnvironment,CreateNewsModel createNewsModel, int userIdLogin);
        Task<IEnumerable<ResponseNewsDetail>> GetAllNewsPosting();
        Task<IEnumerable<NewsType>> GetAllNewsByType(int typeID);
    }
}
