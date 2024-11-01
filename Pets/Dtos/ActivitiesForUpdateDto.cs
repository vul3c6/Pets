using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class ActivitiesForUpdateDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Atype { get; set; }
        [Required]
        public DateTime startTime { get; set; }
        [Required]
        public DateTime endTime { get; set; }
        [Required]
        public float distance { get; set; }
        [Required]
        public int steps { get; set; }
    }
}
