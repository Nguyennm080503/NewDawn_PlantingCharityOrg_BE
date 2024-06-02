using BussinessObjects.Models;

namespace DAO
{
    public class PostingNewsDAO : BaseDAO<PostingNews>
    {
        private static PostingNewsDAO instance = null;
        private readonly DataContext dataContext;

        private PostingNewsDAO()
        {
            dataContext = new DataContext();
        }

        public static PostingNewsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PostingNewsDAO();
                }
                return instance;
            }
        }
    }
}
