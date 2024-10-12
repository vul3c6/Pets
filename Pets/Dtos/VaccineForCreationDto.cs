using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class VaccineForCreationDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Pid { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Vname { get; set; }
        [Required]
        public DateTime Vdate { get; set; }
    }
}
