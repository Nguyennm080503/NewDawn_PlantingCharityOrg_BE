using DTOS.PostingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.News
{
    public class ResponseNewsDetail
    {
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsSummary { get; set; }
        public string Thumbnail { get; set; }
        public string NewsDescription { get; set; }
        public DateTime DateCreate { get; set; }
        public int OwnerCreateID { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

        public List<ResponsePostingDetail> Details { get; set; }
    }
}
