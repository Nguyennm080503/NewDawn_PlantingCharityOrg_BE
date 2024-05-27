namespace BussinessObjects.Models
{
    public class PostingNews
    {
        public int NewsID { get; set; }
        public string NewsTitle { get; set;}
        public string NewsSummary { get; set; }
        public string Thumbnail { get; set; }
        public string NewsDescription { get; set;}
        public DateTime DateCreate { get; set; }
        public int OwnerCreateID { get; set; }
        public UserInformation UserInformation { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
    }
}
