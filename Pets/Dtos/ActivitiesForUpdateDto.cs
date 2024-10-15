using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class ActivitiesForUpdateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Atype { get; set; }
        [Required]
        public int ActivitiesDate { get; set; }
        [Required]
        public int ActivitiesMinute { get; set; }
        [Required]
        public float Distance { get; set; }
        [Required]
        public int Stpes { get; set; }
    }
}
