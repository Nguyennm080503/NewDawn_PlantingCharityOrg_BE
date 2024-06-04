using AutoMapper;
using BussinessObjects.Models;
using DAO;
using DTOS.News;
using Repository.Interface;

namespace Repository.Implement
{
    public class PostingNewsRepository : IPostingNewsRepository
    {
        private readonly IMapper mapper;

        public PostingNewsRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<bool> CreateNews(PostingNews postingNews)
        {
            var result = await PostingNewsDAO.Instance.CreateAsync(postingNews);
            return result;
        }

        public async Task DeleteNews(int id)
        {
            var news = PostingNewsDAO.Instance.GetAllAsync().Result.FirstOrDefault(x => x.NewsID == id);
            news.Status = 1;
            await PostingNewsDAO.Instance.UpdateAsync(news);
        }

        public async Task<IEnumerable<NewsType>> GetAllNewsByType(int typeID)
        {
            var postings = await PostingNewsDAO.Instance.GetAllNewsByType(typeID);
            return mapper.Map<IEnumerable<NewsType>>(postings);
        }

        public async Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth()
        {
            var news = PostingNewsDAO.Instance.GetAllAsync().Result
                .Where(y => y.Type == 1).ToList();

            return mapper.Map<IEnumerable<NewsMonthView>>(news);

        }

        public async Task<IEnumerable<NewsType>> GetAllPostingNews ()
        {
            var responseNews = PostingNewsDAO.Instance.GetAllAsync().Result.Where(x => x.Status == 0);
            return mapper.Map<IEnumerable<NewsType>>(responseNews);
        }

        public async Task<ResponseNewsDetail> GetNewsDetail(int newsID)
        {
            var newsDetail = PostingNewsDAO.Instance.GetAllAsync().Result.FirstOrDefault(x => x.NewsID == newsID);
            return mapper.Map<ResponseNewsDetail>(newsDetail);
        }
    }
}
