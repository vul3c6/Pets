using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class VaccineForUpdateDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string VName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public String VDate { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String VRemark { get; set; }
    }
}
