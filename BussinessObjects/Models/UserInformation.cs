namespace BussinessObjects.Models
{
    public class UserInformation
    {
        public int AccountID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public int RoleID {  get; set; }
        public int Status { get; set; }

        public IEnumerable<PaymentTransaction> UserTransactions { get; set; }
        public IEnumerable<PlantCode> UserPlants { get; set; }
        public IEnumerable<PostingNews> UserPostings { get; set; }
        public Collaborator Collaborator { get; set; }
    }
}
