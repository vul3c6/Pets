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
        public int Amount { get; set; }
        [Required]
        public int waterIntake { get; set; }
    }
}
