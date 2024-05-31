using AutoMapper;
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
        public async Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth()
        {
            var news = PostingNewsDAO.Instance.GetAllAsync().Result
                .Where(y => y.Type == 1).ToList();

            return mapper.Map<IEnumerable<NewsMonthView>>(news);

        }
    }
}
