using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class DietRecoedsForUpdateDto
    {
        [Required]
        public DateTime mealTime { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string foodType { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int waterIntake { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string petReaction { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string DRremark { get; set; }
    }
}
