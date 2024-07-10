using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class myPetForUpdateDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public String Pname { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public String Pbreed { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public String Psex { get; set; }

        [Required]
        public float Pweight { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public String Pborn { get; set; }

    }
}
