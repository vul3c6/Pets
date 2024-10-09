using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class LostForCreationDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")] 
        public string LBreed { get; set; }

        [Required]
        public DateTime LTime { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String LPlace { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String LFeature { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String LContactlnformation { get; set; }

    }
}
