using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class MemberForCreationDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string MAccount { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string MPassword { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string MName { get; set; }
    }
}