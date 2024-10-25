using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class VaccineForUpdateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Vname { get; set; }
        [Required]
        public DateTime Vdate { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Vremark { get; set; }
    }
}
