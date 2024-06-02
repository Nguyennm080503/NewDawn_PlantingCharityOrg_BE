namespace DTOS.Login
{
    public class UserDto
    {
        public int AccountID { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public int RoleID { get; set; }
        public string Token { get; set; }
        public int? Status { get; set; }

    }
}
