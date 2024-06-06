using BussinessObjects.Models;
using DAO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class PostingDetailRepository : IPostingDetailRepository
    {
        public async Task<bool> CreatePostingDetail(PostingDetail postingDetail)
        {
            var result = await PostingDetailDAO.Instance.CreateAsync(postingDetail);
            return result;
        }

        

        public async Task<IEnumerable<PostingDetail>> GetAllPostingDetail()
        {
            var result = await PostingDetailDAO.Instance.GetAllAsync();
            return result;
        }
    }
}
