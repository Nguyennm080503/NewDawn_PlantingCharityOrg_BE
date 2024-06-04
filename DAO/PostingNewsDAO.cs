using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<PostingNews>> GetAllNewsByType(int typeID)
        {
            return await dataContext.PostingNew.Where(x => x.Type == typeID && x.Status == 0).OrderByDescending(x => x.DateCreate).ToListAsync();
        }
        public async Task<PostingNews> GetNewsById(int id)
        {
            return await dataContext.PostingNew.Where(x => x.NewsID == id && x.Status == 0).FirstOrDefaultAsync();
        }
    }
}
