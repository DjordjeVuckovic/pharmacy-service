using System.Collections.ObjectModel;
using System.Windows.Controls;
using TechHealth.Core;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.Windows;
using TechHealth.Model;
using TechHealth.Repository;
namespace TechHealth.DoctorView.ViewModel
{
    public class PatientsViewModel:ViewModelBase
    {
        //public RelayCommand TherapyCommand { get; set; }
        public RelayCommand MedicineRecordCommand { get; set; }
        private ObservableCollection<Patient> patients;
        private Patient selectedItem;
        private HistoryOfCareViewModel historyOfCareViewModel;
        private MedicalRecordViewModel medicalRecordViewModel;
        public string DoctorId { get; set; }
        public RelayCommand HistoryCommand { get; set; }
        public RelayCommand StatusCommand { get; set; }
        public RelayCommand NewHospitalizationCommand { get; set; }
        
        public Patient SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<Patient> Patients
        {
            get
            {
                return patients;
            }
            set
            {
                patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public PatientsViewModel()
        {
            patients = new ObservableCollection<Patient>(PatientRepository.Instance.GetAllToList());
            //currentViewPatient = this;
            HistoryCommand= new RelayCommand(param => Execute(), param => CanExecute());
            MedicineRecordCommand = new RelayCommand(param => Execute1(), param => CanExecute1());
            StatusCommand = new RelayCommand(param => ExecuteHospitalization(),param => CanExecuteHospitalization());
            NewHospitalizationCommand =
                new RelayCommand(param => ExecuteNewHospitalization(), param => CanExecuteNewHospitalization());

        }

        private bool CanExecuteNewHospitalization()
        {
            if (SelectedItem != null)
            {
                return true;
            }

            return false;
        }

        private void ExecuteNewHospitalization()
        {
            NewHospitalization newHospitalization = new NewHospitalization();
            newHospitalization.ShowDialog();
        }

        private bool CanExecuteHospitalization()
        {
            if (SelectedItem != null)
            {
                return true;
            }

            return false;
        }

        private void ExecuteHospitalization()
        {
            HospitalizationView hospitalizationView = new HospitalizationView();
            MainViewModel.GetInstance().CurrentView = hospitalizationView;
        }

        private bool CanExecute()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            historyOfCareViewModel = new HistoryOfCareViewModel(SelectedItem);
            MainViewModel.GetInstance().CurrentView = historyOfCareViewModel;
        }
        private bool CanExecute1()
        {
            if (SelectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void Execute1()
        {
            medicalRecordViewModel = new MedicalRecordViewModel(SelectedItem);
            MainViewModel.GetInstance().CurrentView = medicalRecordViewModel;
        }
    }
}