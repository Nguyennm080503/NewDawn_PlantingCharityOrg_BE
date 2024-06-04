namespace DTOS.News
{
    public class NewsType
    {
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsSummary { get; set; }
        public string Thumbnail { get; set; }
        public string NewsDescription { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
