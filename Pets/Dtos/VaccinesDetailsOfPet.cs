using System.ComponentModel.DataAnnotations;
using Pets.Models;

namespace Pets.Dtos
{
    public class VaccinesDetailsOfPet
    {
        [Required] public Guid Pid { get; set; }
        [Required] public string PName { get; set; }
        [Required] public string PBreed { get; set; }
        // 此Member 所參與的Calendars
        public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
    }
}
