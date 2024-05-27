using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class MemberCheckName
    {
        [Required]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
        public string MAccount { get; set; }
    }
}
