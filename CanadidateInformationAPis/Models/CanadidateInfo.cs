using System.ComponentModel.DataAnnotations;

namespace CanadidateInformationAPis.Models
{
    public class CanadidateInfo
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string BestCallTime { get; set; }

        public string LinkedInURL { get; set; }

        public string GitHubURL { get; set; }

        [Required]
        public string Comment { get; set; }

    }
}
