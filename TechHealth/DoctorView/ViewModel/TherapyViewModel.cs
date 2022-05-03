using System;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class TherapyViewModel:ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private Appointment appointment;
        private DateTime startDate;
        private DateTime finishDate;
        private string description;
        private string frequency;
        private readonly TherapyController therapyController = new TherapyController();
        public string DoctorLabel { get; set; }
        public string PatientLabel { get; set; }
        public RelayCommand FinishCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public TherapyViewModel(Appointment selectedItemAppointment)
        {
            SelectedAppointment = selectedItemAppointment;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            CancelCommand = new RelayCommand(param => CloseWindow());
            DoctorLabel = "Doctor:  " + SelectedAppointment.Doctor.FullSpecialization;
            PatientLabel = "Patient:  " + SelectedAppointment.Patient.FullName;
        }

        public string Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }

        public Appointment SelectedAppointment
        {
            get => appointment;
            set
            {
                appointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }
        
        
        public DateTime StartDateTherapy{
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDateTherapy));
            }
        }
        public DateTime FinishDateTherapy{
            get => finishDate;
            set
            {
                finishDate = value;
                OnPropertyChanged(nameof(FinishDateTherapy));
            }
        }
        public string Description{
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private void CreateTherapy()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            Therapy therapy = new Therapy
            {
                TherapyId = randomGenerator.GenerateRandHash(),
                Appointment = SelectedAppointment,
                StartDate = StartDateTherapy,
                FinishDate = FinishDateTherapy,
                Frequency = Frequency,
                Description = Description
            };
            therapyController.Create(therapy);
            
        }
        private void CloseWindow()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure about that?", @"Cancel appointment", MessageBoxButtons.YesNo);
            if(dialogResult==(DialogResult) MessageBoxResult.Yes)
            {
                OnRequestClose(this, new EventArgs());
            }
        }

        public bool CanExecute()
        {
            if (Frequency != null && Description != null )
            {
                if(StartDateTherapy<FinishDateTherapy)
                    return true;
            }

            return false;

        }

        public void Execute()
        {
            CreateTherapy();
            MessageBox.Show(@"You are successfully create new therapy");
            OnRequestClose(this, new EventArgs());
        }
    }
}