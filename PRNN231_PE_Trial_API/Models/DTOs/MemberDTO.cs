namespace PRNN231_PE_Trial_API.Models.DTOs
{
    public class MemberDTO
    {
        public string Fullname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? CompanyName { get; set; }

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public class UMemberDTO : MemberDTO
    {
        public int MemberId { get; set; }

    }
}
