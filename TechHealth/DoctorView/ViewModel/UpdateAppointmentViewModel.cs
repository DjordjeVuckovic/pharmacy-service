using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class UpdateAppointmentViewModel : ViewModelBase
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
        private Appointment appointment;

        private List<ComboBoxGeneric<Patient>> patientComboBox = new List<ComboBoxGeneric<Patient>>();
        private List<ComboBoxGeneric<Room>> roomComboBox = new List<ComboBoxGeneric<Room>>();
        private ObservableCollection<Appointment> Appointments { get; set; }
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public int PatientIndex { get; set; }
        public int RoomIndex { get; set; }

        public UpdateAppointmentViewModel(string doctorId, Appointment appointmentUpdate)
        {
            appointment = appointmentUpdate;
            doctor = doctorController.GetById(doctorId);
            DoctorFullName = doctor.FullSpecialization;
            FillComboData();
            FillIndex();
            PatientData = appointment.Patient;
            RoomData = appointment.Room;
            Date = appointment.Date;
            StartDate = appointment.StartTimeD.ToString("t");
            EndDate = appointment.FinishTimeD.ToString("t");
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            CancelCommand = new RelayCommand(param => CloseWindow());

        }
        private void CloseWindow()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure about that?", @"Cancel appointment", MessageBoxButtons.YesNo);
            if (dialogResult == (DialogResult)MessageBoxResult.Yes)
            {
                OnRequestClose(this, new EventArgs());
            }
        }

        public bool CanExecute()
        {
            if (StartDate != null && EndDate != null && PatientData != null && RoomData != null)
            {
                if (DateTime.Parse(StartDate) < DateTime.Parse(EndDate))
                    return true;
            }

            return false;

        }

        public void Execute()
        {

            appointment.Date = Date;
            appointment.FinishTimeD = DateTime.Parse(EndDate);
            appointment.StartTimeD = DateTime.Parse(StartDate); ;
            appointment.Patient = PatientData;
            appointment.Room = RoomData;
            appointmentController.Update(appointment);
            MessageBox.Show(@"You are successfully create update appointment");
            OnRequestClose(this, new EventArgs());
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
                roomComboBox.Add(new ComboBoxGeneric<Room>() { DisplayText = r.roomId, Entity = r });
            }
        }

        private void FillIndex()
        {
            int cnt = 0;
            foreach (var combo in patientComboBox)
            {
                if (combo.Entity.Jmbg.Equals(appointment.Patient.Jmbg))
                {
                    break;
                }

                cnt++;
            }

            PatientIndex = cnt;
            cnt = 0;
            foreach (var combo in roomComboBox)
            {
                if (combo.Entity.roomId.Equals(appointment.Room.roomId))
                {
                    break;
                }

                cnt++;
            }

            RoomIndex = cnt;
        }
    }
}