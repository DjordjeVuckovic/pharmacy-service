using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.Windows;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class AnamnesisActionViewModel : ViewModelBase
    {
        private Anamnesis anamnesis;
        private Appointment appointment;
        private readonly AnamnesisController anamnesisController = new AnamnesisController();
        public RelayCommand TherapyCommand { get; set; }
        public RelayCommand PrescribeCommand { get; set; }
        public string AppointmentTypeLabel { get; set; }
        public string PatientLabel { get; set; }
        public string DoctorLabel { get; set; }
        public string RoomLabel { get; set; }
        public string AppointmentDateLabel { get; set; }
        public string AppointmentStartTime { get; set; }
        public string AppointmentFinishTime { get; set; }
        public string AnamesisDate { get; set; }
        public string MainSymptom { get; set; }
        public string OtherSymptoms { get; set; }
        public string GeneralAnamnesis { get; set; }
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
            SelectedAnamnesis = anamnesisController.GetByAppointmentId(appointment.IdAppointment);
            PatientLabel = "Patient:  " + SelectedItemAppointment.Patient.FullName;
            DoctorLabel = "Doctor:  " + SelectedItemAppointment.Doctor.FullSpecialization;
            RoomLabel = "Room:  " + SelectedItemAppointment.Room.roomId;
            AppointmentDateLabel = "Appointment Date:  " + SelectedItemAppointment.Date.ToString("d");
            AppointmentStartTime = "Appointment StartTime:  " + SelectedItemAppointment.StartTimeD.ToString("t");
            AppointmentFinishTime = "Appointment FinishTime:  " + SelectedItemAppointment.FinishTimeD.ToString("t");

            AnamesisDate="Anamesis Date:  " + SelectedAnamnesis.AnamnesisDate.ToString("d");
            MainSymptom = "Main Symptom:  " + SelectedAnamnesis.MainSymptom;

            AnamesisDate = "Anamesis Date:  " + SelectedAnamnesis.AnamnesisDate.ToString("d");
            MainSymptom = "Main Symptom:  " + SelectedAnamnesis.MainIssue;

            OtherSymptoms = "Other Symptoms:  " + SelectedAnamnesis.OtherSymptoms;
            GeneralAnamnesis = "General Anamnesis:  " + SelectedAnamnesis.GeneralAmnesis;
            AppointmentTypeLabel = "Appointment Type: " + SelectedItemAppointment.AppointmentType;
            TherapyCommand = new RelayCommand(param => Execute(), param => CanExecute());
            PrescribeCommand = new RelayCommand(param => Execute1(), param => CanExecute1());
        }

        private bool CanExecute()
        {
            return true;
        }

        private void Execute()
        {
            var vm = new TherapyViewModel(SelectedItemAppointment);
            var therapyWindow = new TherapyWindow()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => therapyWindow.Close();
            therapyWindow.ShowDialog();
        }
        private bool CanExecute1()
        {
            return true;
        }

        private void Execute1()
        {
            var vm = new PrescriptionViewModel(SelectedItemAppointment);
            var prescritionWindow = new PrescriptionWindow()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => prescritionWindow.Close();
            prescritionWindow.ShowDialog();
        }
    }
}