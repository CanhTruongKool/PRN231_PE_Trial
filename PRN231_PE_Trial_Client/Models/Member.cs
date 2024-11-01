namespace PRN231_PE_Trial_Client.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace PRN231_PE_Trial_Client.Models
    {
        public class Member
        {
            [Key]
            public int MemberId { get; set; }

            [Required]
            [StringLength(100)]
            public string Fullname { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [StringLength(100)]
            public string CompanyName { get; set; }

            [StringLength(100)]
            public string City { get; set; }

            [StringLength(100)]
            public string Country { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }

}
