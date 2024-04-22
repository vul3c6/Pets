using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class VaccineForCreationDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string VName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public String VDate { get; set; }
    }
}
