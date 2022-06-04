using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Exceptions;
using TechHealth.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class CreateExaminationViewModel:ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly DoctorController doctorController = new DoctorController();
        private readonly PatientController patientController = new PatientController();
        private readonly RoomController roomController = new RoomController();
        private DateTime date;
        private string startDate;
        private string endDate;
        private Patient patient;
        private Doctor doctor;
        private Room room;

        private List<ComboBoxGeneric<Patient>> patientComboBox = new List<ComboBoxGeneric<Patient>>();
        private List<ComboBoxGeneric<Room>> roomComboBox = new List<ComboBoxGeneric<Room>>();
        private ObservableCollection<Appointment> Appointments { get; set; }
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public CreateExaminationViewModel(string doctorId,ObservableCollection<Appointment> appointmentItems)
        {
            Appointments = appointmentItems;
            doctor = doctorController.GetById(doctorId);
            DoctorFullName = doctor.FullSpecialization;
            FillComboData();
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            CancelCommand = new RelayCommand(param => CloseWindow());

        }
        private void CloseWindow()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure about that?", @"Cancel appointment", MessageBoxButtons.YesNo);
            if(dialogResult==(DialogResult) MessageBoxResult.Yes)
            {
                OnRequestClose?.Invoke(this, new EventArgs());
            }
        }

        public bool CanExecute()
        {
            if (StartDate != null && EndDate != null && PatientData != null && RoomData != null )
            {
                if(DateTime.Parse(StartDate)<DateTime.Parse(EndDate))
                    return true;
            }

            return false;

        }

        public void Execute()
        {
            Appointment appointment = new Appointment
            {
                AppointmentType = AppointmentType.examination,
                Date = Date,
                Doctor = doctor,
                Emergent = false,
                FinishTime = DateTime.Parse(EndDate),
                IdAppointment = Guid.NewGuid().ToString("N"),
                Patient = PatientData,
                Room = RoomData,
                StartTime = DateTime.Parse(StartDate),
                ShouldSerialize = true
            };
            try
            {
                appointmentController.Create(appointment);
                Appointments.Add(appointment);
                RecordViewModel.GetInstance().Appointments.Add(appointment);
                MessageBox.Show(@"You are successfully create new examination");
            }
            catch (AppointmentConflictException)
            {
                MessageBox.Show(@"Doctor has already scheduled appointment in that period!",@"Appointment exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
            OnRequestClose?.Invoke(this, new EventArgs());
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

        public string StartDate
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

        public string EndDate
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
        public Room RoomData
        {
            get => room;
            set
            {
                room = value;
                OnPropertyChanged(nameof(RoomData));
            }
        }
        private void FillComboData()
        {

            foreach (var p in patientController.GetAll())
            {
                patientComboBox.Add(new ComboBoxGeneric<Patient>() { DisplayText = p.Name + " " + p.Surname, Entity = p });
            }

            foreach (var r in roomController.GetAll())
            {
                roomComboBox.Add(new ComboBoxGeneric<Room>(){DisplayText = r.RoomId , Entity = r});
            }
        }
    }
}