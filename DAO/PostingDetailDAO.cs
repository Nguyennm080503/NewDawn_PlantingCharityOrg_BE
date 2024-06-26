﻿using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PostingDetailDAO : BaseDAO<PostingDetail>
    {
        private static PostingDetailDAO instance = null;
        private readonly DataContext dataContext;

        private PostingDetailDAO()
        {
            dataContext = new DataContext();
        }

        public static PostingDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PostingDetailDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<PostingDetail>> GetAllPostingNews(int postingID)
        {
            return await dataContext.PostingDetail.Where(x => x.PostingNewsID == postingID).ToListAsync();
        }
    }
}
