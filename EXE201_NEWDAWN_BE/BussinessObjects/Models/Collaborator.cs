namespace BussinessObjects.Models
{
    public class Collaborator
    {
        public int CollaboratorID { get; set; }
        public UserInformation UserInformation { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string RegisterName { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }

        public IEnumerable<BannerMember> BannerMembers { get; set; }
        public IEnumerable<MemberRegisterPackage> UserMemberRegistrations { get; set; }
    }
}
