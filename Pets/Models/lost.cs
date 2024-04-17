using System.ComponentModel.DataAnnotations;
namespace Pets.Models
{
    public class lost
    {
        public Guid Lid { get; set; }
        public String LBreed { get; set; }
        public String LTime { get; set; }
        public String LPlace { get; set; }
        public String LFeature { get; set; }
        public String LContactlnformation { get; set; }
    }
}
