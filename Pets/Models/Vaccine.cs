﻿namespace Pets.Models
{
    public class Vaccine
    {
        public Guid Vid { get; set; }
        public Guid Pid { get; set; }
        public string VName { get; set; }
        public DateTime Vdate { get; set; }
        public string Vremarks { get; set; }
    }
}
