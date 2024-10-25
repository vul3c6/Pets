using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class ActivitiesForCreactionDto
    {
        [Required]
        public string Pid { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Atype { get; set; }
        [Required]
        public DateTime startTime { get; set; }
        [Required]
        public DateTime endTime { get; set; }

        //[Required]
        //public float Distance { get; set; }
        //[Required]
        //public int Steps { get; set; }
    }
}
