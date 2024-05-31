using AutoMapper;
using BussinessObjects.Models;
using DTOS.News;
using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PostingNewsService : IPostingNewsService
    {
        private readonly IPostingNewsRepository _postingNewsRepository;
        public PostingNewsService(IPostingNewsRepository postingNewsRepository) 
        {
            _postingNewsRepository = postingNewsRepository;
        }

        public async Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth()
        {
            var news = await _postingNewsRepository.GetAllNewsEachMonth();
            return news;
        }

        public async Task<bool> CreateNews(CreateNewsModel createNewsModel)
        {
            var createNewsEntity = _mapper.Map<PostingNews>(createNewsModel);
            var result = await _postingNewsRepository.CreateNews(createNewsEntity);
            return result;
        }

    }
}
