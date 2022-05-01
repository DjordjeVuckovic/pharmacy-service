using System;

namespace TechHealth.Model
{
    public class Therapy
    {
        public string TherapyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Frequency { get; set; }
        public string Description { get; set; }
        public Appointment Appointment { get; set; }
        public bool ShouldSerialize { get; set; }
        public bool ShouldSerializePatient()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeDoctor()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeStartDate()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeFinishDate()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeFrequency()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeDescription()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeAppointment()
        {
            return ShouldSerialize;
        }
    }
}