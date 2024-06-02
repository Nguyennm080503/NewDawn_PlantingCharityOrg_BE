namespace BussinessObjects.Models
{
    public class Package
    {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public double PackageFee { get; set; }
        public int PackageType { get; set; }
        public int Month { get; set; }
        public int Status { get; set; }

        public IEnumerable<MemberRegisterPackage> RegisterPackages { get; set; }
    }
}
