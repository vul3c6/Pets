namespace Pets.Models
{
    public class Activities
    {
        public Guid Aid { get; set; }
        public string Pid { get; set; }
        public string Atype { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public float distance { get; set; }
        public int steps { get; set; }
    }
}
