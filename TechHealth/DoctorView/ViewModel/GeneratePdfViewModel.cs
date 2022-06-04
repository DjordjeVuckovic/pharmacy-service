using System;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class GeneratePdfViewModel:ViewModelBase
    {
        private Patient patient;
        private readonly PatientController patientController = new PatientController();

        public String LabelPatientName { get; set; }
        public String LabelDoctorName { get; set; }
        public RelayCommand AcceptCommand { get; set; }
        private DateTime startDate;
        private DateTime endDate;
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
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

        public GeneratePdfViewModel(Patient patient)
        {
            patient = patientController.GetByPatientId(patient.Jmbg);
            LabelDoctorName = "John Black";
            LabelPatientName = patient.FullName;
            AcceptCommand = new RelayCommand(param => ExecutePdf(),param => CanExecutePdf());
        }

        private bool CanExecutePdf()
        {
            if (StartDate <= EndDate)
            {
                return true;
            }

            return false;
        }

        private void ExecutePdf()
        {
            
        }
        
    }
}