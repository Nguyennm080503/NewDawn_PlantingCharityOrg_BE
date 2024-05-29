using DTOS.News;

namespace Service.Interface
{
    public interface IPostingNewsService
    {
        Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth();
        Task<bool> CreateNews(CreateNewsModel createNewsModel);
    }
}
