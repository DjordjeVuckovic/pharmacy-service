using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class AnamnesisActionViewModel:ViewModelBase
    {
        private Anamnesis anamnesis;
        private Appointment appointment;
        private readonly AnamnesisController anamnesisController = new AnamnesisController();
        public string PatientLabel { get; set; }
        public string DoctorLabel { get; set; }
        public string RoomLabel { get; set; }
        public string AppointmentDateLabel { get; set; }
        public string AppointmentStartTime { get; set; }
        public string AppointmentFinishTime { get; set; }
        public string AnamesisDate { get; set; }
        public string MainSymptom { get; set; }
        public string OtherSymptoms { get; set; }
        public string GeneralAnamnesis{ get; set; }
        public Appointment SelectedItemAppointment
        {
            get => appointment;
            set
            {
                appointment = value;
                OnPropertyChanged(nameof(SelectedItemAppointment));
            }
        }

        public Anamnesis SelectedAnamnesis
        {
            get => anamnesis;
            set
            {
                anamnesis = value;
                OnPropertyChanged(nameof(SelectedAnamnesis));
            }
        }
        public AnamnesisActionViewModel(Appointment selectedItem)
        {
            SelectedItemAppointment = selectedItem;
            SelectedAnamnesis=anamnesisController.GetByAppointmentId(appointment.IdAppointment);
            PatientLabel = "Patient:  " + SelectedItemAppointment.Patient.FullName;
            DoctorLabel = "Doctor:  " + SelectedItemAppointment.Doctor.FullSpecialization;
            RoomLabel = "Room:  " + SelectedItemAppointment.Room.roomId;
            AppointmentDateLabel= "Appointment Date:  " + SelectedItemAppointment.Date.ToString("d");
            AppointmentStartTime= "Appointment StartTime:  " + SelectedItemAppointment.StartTimeD.ToString("t");
            AppointmentFinishTime = "Appointment FinishTime:  " + SelectedItemAppointment.FinishTimeD.ToString("t");
            AnamesisDate="Anamesis Date:  " + SelectedAnamnesis.AnamnesisDate.ToString("d");
            MainSymptom = "Main Symptom:  " + SelectedAnamnesis.MainIssue;
            OtherSymptoms = "Other Symptoms:  " + SelectedAnamnesis.OtherSymptoms;
            GeneralAnamnesis = "General Anamnesis:  " + SelectedAnamnesis.GeneralAmnesis;
            
        }
    }
}