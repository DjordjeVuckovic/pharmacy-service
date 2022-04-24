using System;

namespace TechHealth.Model
{
    public class Therapy
    {
        public string TherapyId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Frequency { get; set; }
        public string Description { get; set; }
    }
}