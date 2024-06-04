using BussinessObjects.Models;
using DTOS.News;

namespace Repository.Interface
{
    public interface IPostingNewsRepository
    {
        Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth();
        Task<bool> CreateNews(PostingNews postingNews);
        Task<IEnumerable<NewsType>> GetAllPostingNews();
        Task<IEnumerable<NewsType>> GetAllNewsByType(int typeID);
        Task<PostingNews> GetNewsDetailById(int id);
        Task<bool> DeleteNewsById(int id);
    }
}
