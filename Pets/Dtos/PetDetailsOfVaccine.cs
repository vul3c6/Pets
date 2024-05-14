using System.ComponentModel.DataAnnotations;
using Pets.Models;

namespace Pets.Dtos
{
    public class PetDetailsOfVaccine
    {
        [Required] public Guid Vid { get; set; }
        [Required] public string VName { get; set; }
        // 此Calendars 所參與的Member
        public List<myPet> myPets { get; set; } = new List<myPet>();
    }
}
