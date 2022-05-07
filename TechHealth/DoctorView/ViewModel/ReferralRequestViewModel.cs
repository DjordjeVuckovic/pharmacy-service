using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
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
        private List<ComboBoxGeneric<Specialization>> specComboBox = new List<ComboBoxGeneric<Specialization>>();
        private ObservableCollection<ComboBoxGeneric<Doctor>> doctorComboBox = new ObservableCollection<ComboBoxGeneric<Doctor>>();
        private readonly SpecializationController specializationController = new SpecializationController();
        private readonly  DoctorController doctorController = new DoctorController();
        private readonly ReferralRequestController referralRequestController = new ReferralRequestController();

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
        public ReferralRequestViewModel(Appointment selectedItemAppointment)
        {
            selectedAppointment = selectedItemAppointment;
            FillSpecializationComboBox();
            DoctorLabel = "Appointment Doctor: " + selectedItemAppointment.Doctor.FullName;
            DateLabel = "Appointment Date: " + selectedItemAppointment.Date.ToString("d");
            PateintLabel = "Patient: " + selectedItemAppointment.Patient.FullName;
            FinishCommand = new RelayCommand(param => ExecuteCreate(), param => CanExecuteCreate());
            CancelCommand = new RelayCommand(param => CloseWindow());
            

        }
        public void Execute()
        {
            FillDoctorComboBox();
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
                OnRequestClose(this, new EventArgs());
            }
        }

        public bool CanExecuteCreate()
        {
            if (DoctorData != null && SpecializationData != null )
            {
                return true;
            }

            return false;

        }

        public void ExecuteCreate()
        {
            CreateRefferal();
            MessageBox.Show(@"You are successfully create new therapy");
            OnRequestClose(this, new EventArgs());
        }

        private void CreateRefferal()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            ReferralRequest referralRequest = new ReferralRequest
            {
                ReferralId = randomGenerator.GenerateRandHash(),
                Appointment = selectedAppointment,
                ReferralDoctor = DoctorData
            };
            referralRequestController.Create(referralRequest);
        }
    }
}