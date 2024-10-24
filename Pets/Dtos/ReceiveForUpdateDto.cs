﻿using System.ComponentModel.DataAnnotations;

namespace Pets.Dtos
{
    public class ReceiveForUpdateDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        public string RBreed { get; set; }

        [Required]
        public DateTime RTime { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String RPlace { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String RFeature { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String RContactlnformation { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public String Maccount { get; set; }
    }
}
