using AutoMapper;
using BussinessObjects.Models;
using DAO;
using DTOS.News;
using Repository.Interface;

namespace Repository.Implement
{
    public class PostingNewsRepository : IPostingNewsRepository
    {
        public async Task<bool> CreateNews(PostingNews postingNews)
        {
            var result = await PostingNewsDAO.Instance.CreateAsync(postingNews);
            return result;
        }

        public async Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth()
        {
            var news = PostingNewsDAO.Instance.GetAllAsync().Result
                .Where(y => y.Type == 1)
                .Select(x => new NewsMonthView
                {
                    NewsID = x.NewsID,
                    NewsSummary = x.NewsSummary,
                    Thumbnail = x.Thumbnail,
                    DateCreate = x.DateCreate
                }).ToList();

            return news;

        }
    }
}
