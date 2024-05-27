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
    }
}
