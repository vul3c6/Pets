using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class MemberForCreationDto
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

        //[Required]
        //public DateTime Mborn { get; set; }

        [Required]
        public char Msex { get; set; }
    }
}