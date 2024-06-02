using BussinessObjects.Models;
using DTOS.News;

namespace Repository.Interface
{
    public interface IPostingNewsRepository
    {
        Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth();
        Task<bool> CreateNews(PostingNews postingNews);
        Task<IEnumerable<PostingNews>> GetAllPostingNews();
        Task<IEnumerable<NewsType>> GetAllNewsByType(int typeID);
    }
}
