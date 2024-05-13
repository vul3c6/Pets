using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class myPetForUpdateDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public String PName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public String PBreed { get; set; }

        [Required]
        public float PWeight { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public String PBorn { get; set; }

    }
}
