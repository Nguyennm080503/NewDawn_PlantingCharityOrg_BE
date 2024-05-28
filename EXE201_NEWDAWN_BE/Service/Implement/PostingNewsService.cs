using AutoMapper;
using DTOS.News;
using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PostingNewsService : IPostingNewsService
    {
        private readonly IPostingNewsRepository _postingNewsRepository;
        private readonly IMapper _mapper;
        public PostingNewsService(IPostingNewsRepository postingNewsRepository, IMapper mapper) 
        {
            _postingNewsRepository = postingNewsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth()
        {
            var news = await _postingNewsRepository.GetAllNewsEachMonth();
            return news;
        }
    }
}
