using System;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.GeneratePdf;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class GeneratePdfViewModel:ViewModelBase
    {
        private Patient selectedPatient;
        private readonly PatientController patientController = new PatientController();
        private readonly DoctorController doctorController = new DoctorController();
        public event EventHandler OnRequestClose;

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
            selectedPatient = patientController.GetByPatientId(patient.Jmbg);
            LabelDoctorName = doctorController.GetById(MainViewModel.DoctorId).FullSpecialization;
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
            new PdfForPateintCare(selectedPatient, StartDate, EndDate);
            OnRequestClose?.Invoke(this, EventArgs.Empty);

        }
        
    }
}