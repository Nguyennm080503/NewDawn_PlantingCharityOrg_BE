using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.News
{
    public class CreateNewsModel
    {
        public string NewsTitle { get; set; }
        public string NewsSummary { get; set; }
        public string Thumbnail { get; set; }
        public string NewsDescription { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public IFormFile fileImage {  get; set; }
    }
}
