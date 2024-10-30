using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class MemberForUpdateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Maccount { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Mpassword { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Mname { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Memail { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "Maximum 1 characters")]
        public string Msex { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public string Mdate { get; set; }
    }
}
