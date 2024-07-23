using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class MemberForLoginDto
    {
        [Required]
        public string Maccount { get; set; }
        [Required]
        public string Mpassword { get; set; }
    }
}
