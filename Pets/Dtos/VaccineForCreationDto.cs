﻿using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class VaccineForCreationDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Pid { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Vname { get; set; }
        [Required]
        public DateTime Vdate { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Maximum 255 characters")]
        public string Vremarks { get; set; }
    }
}
