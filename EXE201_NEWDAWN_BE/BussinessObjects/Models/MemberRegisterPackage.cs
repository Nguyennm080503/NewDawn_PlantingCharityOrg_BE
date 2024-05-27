namespace BussinessObjects.Models
{
    public class MemberRegisterPackage
    {
        public int MemberRegisterPackagenID { get; set; }
        public Package Package { get; set; }
        public int? PackageID { get; set; }
        public Collaborator Register { get; set; }
        public int? RegisterID { get; set; }
        public DateTime? DateRegister { get; set; }
        public DateTime? DateExpire { get; set; }
        public double PackageFee { get; set; }
        public int Status { get; set; }
    }
}
