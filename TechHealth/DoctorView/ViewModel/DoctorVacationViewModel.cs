using System;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Exceptions;
using TechHealth.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class DoctorVacationViewModel:ViewModelBase
    {
        public event EventHandler OnRequestClose;
        private readonly Doctor doctor;
        private DateTime startDate;
        private DateTime finishDate;
        private string reason;
        private bool emergent;
        private readonly DoctorVacationRequestController doctorVacationRequestController = new DoctorVacationRequestController();
        private RelayCommand finishCommand;

        public bool Emergent
        {
            get => emergent;
            set
            {
                emergent = value;
                OnPropertyChanged(nameof(Emergent));
            }
        }
        
        public DateTime StartDate{
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime FinishDate{
            get => finishDate;
            set
            {
                finishDate = value;
                OnPropertyChanged(nameof(FinishDate));
            }
        }
        public string Reason
        {
            get => reason;
            set
            {
                reason = value;
                OnPropertyChanged(nameof(Reason));
            }
        }
        public string DoctorTxt { get; set; }

        public RelayCommand FinishCommand
        {
            get
            {
                return finishCommand ?? (finishCommand = new RelayCommand(param => Execute(), param => CanExecute()));
            }
        }

        public RelayCommand CancelCommand { get; set; }
        public DoctorVacationViewModel(Doctor doctor)
        {
            this.doctor = doctor;
            DoctorTxt = doctor.FullSpecialization;
            CancelCommand = new RelayCommand(param => CloseWindow());
        }
        private void CloseWindow()
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure?", @"Cancel vacation", MessageBoxButtons.YesNo);
            if(dialogResult==(DialogResult) MessageBoxResult.Yes)
            {
                OnRequestClose(this, new EventArgs());
            }
        }

        public bool CanExecute()
        {
            
            if (Reason != null)
            {
                if (StartDate >= DateTime.Now.Date.AddDays(2) && FinishDate >= DateTime.Now.Date.AddDays(2))
                {
                    return true;
                }
            }

            return false;

        }

        public void Execute()
        {
            if (Emergent)
            {
                CreateEmergent();
            }
            else
            {
                CreateNotEmergent();
            }

            if (OnRequestClose != null) OnRequestClose(this, EventArgs.Empty);
        }

        private void CreateNotEmergent()
        {
            RandomGenerator random = new RandomGenerator();
            DoctorVacationRequest doctorVacationRequest = new DoctorVacationRequest
            {
                VacationId = random.GenerateRandHash(),
                StartDate = StartDate,
                FinishDate = FinishDate,
                Doctor = doctor,
                VacationReason = Reason,
                Emergent = false,
                VacationStatus = VacationStatus.Waiting
            };
            try
            {
                doctorVacationRequestController.CreateNotEmergentVacation(doctorVacationRequest);
                MessageBox.Show(@"You are successfully scheduled new vacation");
            }
            catch(SpecializationException)
            {
                MessageBox.Show(@"More then one doctor with same specialization is already on vacation!",@"Vacation exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void CreateEmergent()
        {
            RandomGenerator random = new RandomGenerator();
            DoctorVacationRequest doctorVacationRequest = new DoctorVacationRequest
            {
                VacationId = random.GenerateRandHash(),
                StartDate = StartDate,
                FinishDate = FinishDate,
                Doctor = doctor,
                VacationReason = Reason,
                Emergent = true,
                VacationStatus = VacationStatus.Waiting
            };
            doctorVacationRequestController.CreateEmergentVacation(doctorVacationRequest);
            MessageBox.Show(@"You are successfully scheduled new vacation");
        }
    }
}