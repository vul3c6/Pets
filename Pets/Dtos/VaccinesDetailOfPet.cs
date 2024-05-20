using Pets.Models;
using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class VaccinesDetailOfPet
    {
        [Required] public Guid Pid { get; set; }
        [Required] public string PName { get; set; }
        [Required] public string PBreed{ get; set; }
        // 此寵物所打過的疫苗
        public List<Vaccine> Vaccines{ get; set; } = new List<Vaccine>();
    }
}