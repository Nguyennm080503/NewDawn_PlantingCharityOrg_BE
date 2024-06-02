namespace BussinessObjects.Models
{
    public class PostingDetail
    {
        public int PostingDetailID {get; set;}
        public int PostingNewsID { get; set;}
        public PostingNews PostingNews { get; set;}
        public string URLPosting {  get; set;}
    }
}
