namespace TechHealth.Model
{
    public class RejectedMedicine
    {
        public string RejectedMedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public string Reason { get; set; }
        public Doctor Doctor { get; set; }
    }
}