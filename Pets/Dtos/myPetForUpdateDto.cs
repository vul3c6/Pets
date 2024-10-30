using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class myPetForUpdateDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Pname { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public string Pbreed { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "Maximum 1 characters")]
        public string Psex { get; set; }

        [Required]
        public float Pweight { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Pborn { get; set; }

    }
}
