namespace BussinessObjects.Models
{
    public class BannerMember
    {
        public int BannerID { get; set; }
        public string BannerName { get; set;}
        public string BannerUrl { get; set;}
        public int MemberID { get; set; }
        public Collaborator Collaborator { get; set; }
        public int Status { get; set; }
    }
}
