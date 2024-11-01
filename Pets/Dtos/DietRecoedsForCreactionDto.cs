using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class DietRecoedsForCreactionDto
    {
        [Required]
        public string Pid { get; set; }
        [Required]
        public DateTime mealTime { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public int waterIntake { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string petReaction { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Maximum 255 characters")]
        public string DRremark { get; set; }
    }
}
