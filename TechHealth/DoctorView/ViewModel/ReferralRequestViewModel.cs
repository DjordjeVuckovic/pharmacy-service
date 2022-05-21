using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Exceptions;
using TechHealth.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class ReferralRequestViewModel:ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private Appointment selectedAppointment;
        private RelayCommand specializationCommand;
        private Specialization specialization;
        private Doctor doctor;
        private DateTime date;
        private string startDate;
        private string endDate;
        private List<ComboBoxGeneric<Specialization>> specComboBox = new List<ComboBoxGeneric<Specialization>>();
        private ObservableCollection<ComboBoxGeneric<Doctor>> doctorComboBox = new ObservableCollection<ComboBoxGeneric<Doctor>>();
        private readonly SpecializationController specializationController = new SpecializationController();
        private readonly  DoctorController doctorController = new DoctorController();
        private readonly ReferralRequestController referralRequestController = new ReferralRequestController();
        private readonly AppointmentController appointmentController = new AppointmentController();
        private readonly RoomController roomController = new RoomController();

        public RelayCommand SpecializationCommand
        {
            get
            {
                specializationCommand = new RelayCommand(param => Execute());
                return specializationCommand;
            }
        }
        public string DoctorLabel { get; set; }
        public string PateintLabel { get; set; }
        public string DateLabel { get; set; }
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        private List<ComboBoxGeneric<Room>> roomComboBox = new List<ComboBoxGeneric<Room>>();
        private Room room;

        public Specialization SpecializationData
        {
            get => specialization;
            set
            {
                specialization = value;
                OnPropertyChanged(nameof(SpecializationData));
            }
        }

        public ObservableCollection<ComboBoxGeneric<Doctor>> DoctorComboBox
        {
            get => doctorComboBox;
            set
            {
                
                doctorComboBox = value;
                OnPropertyChanged(nameof(DoctorComboBox));
            }
        }
        public List<ComboBoxGeneric<Specialization>> SpecComboBox
        {
            get => specComboBox;
            set
            {
                specComboBox = value;
                OnPropertyChanged(nameof(SpecComboBox));
            }
        }
        public Doctor  DoctorData
        {
            get => doctor;
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(DoctorData));
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
            set => SetProperty(ref date, value);
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

        public ReferralRequestViewModel(Appointment selectedItemAppointment)
        {
            selectedAppointment = selectedItemAppointment;
            FillSpecializationComboBox();
            FillRoomCombo();
            DoctorLabel = "Appointment Doctor: " + selectedItemAppointment.Doctor.FullName;
            DateLabel = "Appointment Date: " + selectedItemAppointment.Date.ToString("d");
            PateintLabel = "Patient: " + selectedItemAppointment.Patient.FullName;
            FinishCommand = new RelayCommand(param => ExecuteCreate(), param => CanExecuteCreate());
            CancelCommand = new RelayCommand(param => CloseWindow());
            

        }

        private void FillRoomCombo()
        {
            foreach (var r in roomController.GetAll())
            {
                roomComboBox.Add(new ComboBoxGeneric<Room>(){DisplayText = r.roomId , Entity = r});
            }
        }

        public void Execute()
        {
            FillDoctorComboBox();
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
        public Room RoomData
        {
            get => room;
            set
            {
                room = value;
                OnPropertyChanged(nameof(RoomData));
            }
        }
        

        private void FillSpecializationComboBox()
        {
            foreach (var s in specializationController.GetAll())
            {
                specComboBox.Add(new ComboBoxGeneric<Specialization>() { DisplayText = s.NameSpecialization, Entity = s });
            }
        }

        private void FillDoctorComboBox()
        {
            doctorComboBox.Clear();
            foreach (var d in doctorController.GetAllBySpecializationId(SpecializationData.IdSpecialization))
            {
                doctorComboBox.Add(new ComboBoxGeneric<Doctor>() {DisplayText = d.FullName, Entity = d});
            }
        }
        private void CloseWindow()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure about that?", @"Cancel appointment", MessageBoxButtons.YesNo);
            if(dialogResult==(DialogResult) MessageBoxResult.Yes)
            {
                OnRequestClose?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool CanExecuteCreate()
        {
            if (DoctorData != null && SpecializationData != null && RoomData !=null && Date > DateTime.Today && DateTime.Parse(StartDate) < DateTime.Parse(EndDate))
            {
                return true;
            }

            return false;

        }

        private void ExecuteCreate()
        {
            CreateReferralAppointment();
        }

        private void CreateRefferal()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            ReferralRequest referralRequest = new ReferralRequest
            {
                ReferralId = randomGenerator.GenerateRandHash(),
                Appointment = selectedAppointment,
                ReferralDoctor = DoctorData,
                Date = Date,
                StartTime = DateTime.Parse(StartDate),
                FinishTime = DateTime.Parse(EndDate),
            };
            referralRequestController.Create(referralRequest);
        }

        private void CreateReferralAppointment()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            Appointment appointment = new Appointment
            {
                Date = Date,
                Emergent = false,
                IdAppointment = randomGenerator.GenerateRandHash(),
                Room = RoomData,
                Patient = selectedAppointment.Patient,
                AppointmentType = AppointmentType.examination,
                Doctor = DoctorData,
                Evident = false,
                StartTimeD = DateTime.Parse(StartDate),
                FinishTimeD = DateTime.Parse(EndDate),
                ShouldSerialize = true
            };
            try
            {
                appointmentController.Create(appointment);
                CreateRefferal();
                RecordViewModel.GetInstance().RefreshView();
                ViewModelAppointment.GetInstance().RefreshView();
                MessageBox.Show(@"You are successfully create new referral");
                OnRequestClose?.Invoke(this, EventArgs.Empty);
            }
            catch (AppointmentConflictException)
            {
                MessageBox.Show(@"Doctor has already scheduled appointment in that period!Change date or time.",@"Appointment exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}