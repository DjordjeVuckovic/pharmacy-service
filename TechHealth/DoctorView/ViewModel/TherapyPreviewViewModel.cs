using System;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class TherapyPreviewViewModel:ViewModelBase
    {
        public event EventHandler OnRequestClose;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Frequency { get; set; }
        public string Description { get; set; }
        private Therapy therapy;
        public string DoctorName { get; set; }
        public string RoomId { get; set; }
        public string PatientName { get; set; }
        //private readonly  AppointmentController appointmentController = new AppointmentController();
        public RelayCommand CloseCommand {get; set; }
        
        

        public TherapyPreviewViewModel(Therapy selectedTherapy, Patient selectedItemPatient)
        {
            //Appointment appointment = appointmentController.GetById(selectedTherapy.Appointment.IdAppointment);
            therapy = selectedTherapy;
            StartDate = selectedTherapy.StartDate;
            FinishDate = selectedTherapy.FinishDate;
            Description = selectedTherapy.Description;
            Frequency = selectedTherapy.Frequency;
            DoctorName = "Doctor: " + selectedTherapy.Appointment.Doctor.FullSpecialization;
            PatientName = "Patient: " + selectedItemPatient.FullName;
            RoomId = "AppointmentRoom: " + selectedTherapy.Appointment.Room.RoomId;
            CloseCommand = new RelayCommand(param => CloseWindow());

        }
        private void CloseWindow()
        {
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}