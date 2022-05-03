using System;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class TherapyPreviewViewModel:ViewModelBase
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Frequency { get; set; }
        public string Description { get; set; }
        private Therapy therapy;
        public string DoctorName { get; set; }
        public string RoomId { get; set; }
        public string PatientName { get; set; }
        
        

        public TherapyPreviewViewModel(Therapy selectedTherapy, Patient selectedItemPatient)
        {
            therapy = selectedTherapy;
            StartDate = selectedTherapy.StartDate;
            FinishDate = selectedTherapy.FinishDate;
            Description = selectedTherapy.Description;
            Frequency = selectedTherapy.Frequency;
            DoctorName = "Doctor: " + selectedTherapy.Appointment.Doctor.FullSpecialization;
            RoomId = "Room: " + selectedTherapy.Appointment.Room.roomId;
            PatientName = "Patient: " + selectedItemPatient.FullName;

        }
    }
}