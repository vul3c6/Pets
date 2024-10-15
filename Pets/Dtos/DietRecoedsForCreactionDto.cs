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
    }
}
