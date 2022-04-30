using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class CreateSurgeryViewModel:ViewModelBase
    {
        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly DoctorController doctorController = new DoctorController();
        private readonly PatientController patientController = new PatientController();
        private readonly RoomController roomController = new RoomController();
        private DateTime date;
        private DateTime startDate;
        private DateTime endDate;
        private Patient patient;
        private Doctor doctor;

        private List<ComboBoxGeneric<Patient>> patientComboBox = new List<ComboBoxGeneric<Patient>>();
        private List<ComboBoxGeneric<Room>> roomComboBox = new List<ComboBoxGeneric<Room>>();
        private ObservableCollection<Appointment> Appointments { get; set; }
        private RelayCommand FinishCommand { get; set; }
        private RelayCommand CancelCommand { get; set; }

        public CreateSurgeryViewModel(string doctorId,ObservableCollection<Appointment> appointmentItems)
        {
            Appointments = appointmentItems;
            doctor = doctorController.GetById(doctorId);
            DoctorFullName = doctor.FullSpecialization;
            FillComboData();

        }

        public string DoctorFullName { get; set; }

        public List<ComboBoxGeneric<Patient>> PatientComboBox
        {

            get => patientComboBox;
            set
            {
                patientComboBox = value;
                OnPropertyChanged(nameof(PatientComboBox));
            }
        }
        public List<ComboBoxGeneric<Room>> RoomComboBox
        {

            get => roomComboBox;
            set
            {
                roomComboBox = value;
                OnPropertyChanged(nameof(RoomComboBox));
            }
        }

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public Patient PatientData
        {
            get => patient;
            set
            {
                patient = value;
                OnPropertyChanged(nameof(PatientData));
            }
        }
        // private void ButtonBase_OnClick1()
        // {
        //     MessageBoxResult dialogResult = MessageBox.Show("Are you sure about that?", "Cancel appointment", MessageBoxButton.YesNo);
        //     if(dialogResult==MessageBoxResult.Yes)
        //     {
        //         Close();
        //     }
        // }
        private void FillComboData()
        {

            foreach (var p in patientController.GetAll())
            {
                patientComboBox.Add(new ComboBoxGeneric<Patient>() { DisplayText = p.Name + " " + p.Surname, Entity = p });
            }

            foreach (var r in roomController.GetAll())
            {
                roomComboBox.Add(new ComboBoxGeneric<Room>(){DisplayText = r.roomId , Entity = r});
            }
        }
    }
}