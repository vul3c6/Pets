using Pets.Models;
using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class PetDetailsOfMember
    {
        [Required] public Guid Mid { get; set; }
        [Required] public string MAccount { get; set; }
        [Required] public string MName { get; set; }
        // 此Member 所參與的Pets
        public List<myPet> Pets { get; set; } = new List<myPet>();
    }
}