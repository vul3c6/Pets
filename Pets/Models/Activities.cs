namespace Pets.Models
{
    public class Activities
    {
        public Guid Aid { get; set; }
        public string Pid { get; set; }
        public string Atype { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public float Distance { get; set; }
        public int Steps { get; set; }
    }
}
