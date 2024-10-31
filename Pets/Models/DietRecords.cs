namespace Pets.Models
{
    public class DietRecords
    {
        public Guid DRid { get; set; }
        public Guid Pid { get; set; }
        public DateTime mealTime {  get; set; }
        public string foodType { get; set; }
        public int Amount { get; set; }
        public int waterIntake { get; set; }
        public string petReaction { get; set; }
        public string DRremark { get; set; }
    }
}
