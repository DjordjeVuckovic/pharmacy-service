// File:    Prescription.cs
// Author:  djord
// Created: Saturday, April 2, 2022 9:36:28 PM
// Purpose: Definition of Class Prescription

using System;

namespace TechHealth.Model
{
    public class Prescription
    {
        public string PrescriptionId { get; set; }
        public Medicine Medicine { get; set; }
        public string Frequency { get; set; }
        public string Usage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public bool ShouldSerialize { get; set; }
        public Appointment Appointment { get; set; }
        public bool ShouldSerializeMedicine()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeFrequency()
        {
            return ShouldSerialize;
        }

        public bool ShouldSerializeUsage()
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
        public bool ShouldSerializeAppointment()
        {
            return ShouldSerialize;
        }

    }
}