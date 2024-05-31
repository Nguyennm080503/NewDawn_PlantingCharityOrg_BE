using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IPostingDetailRepository
    {
        Task<bool> CreatePostingDetail(PostingDetail postingDetail);
        Task<IEnumerable<PostingDetail>> GetAllPostingDetail();
    }
}
