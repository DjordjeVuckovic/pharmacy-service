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
        public RelayCommand TherapyCommand { get; set; }
        public RelayCommand MedicineRecordCommand { get; set; }
        private ObservableCollection<Patient> patients;
        private Patient selectedItem;
        private TherapyWindow therapyWindow;
        private MedicalRecordViewModel MedicalRecordViewModel;
        private readonly MainViewModel mainViewModel;
        public string DoctorId { get; set; }
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
            TherapyCommand= new RelayCommand(param => Execute(), param => CanExecute());
            MedicineRecordCommand = new RelayCommand(param => Execute1(), param => CanExecute1());
            
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
            therapyWindow = new TherapyWindow(SelectedItem);
            therapyWindow.ShowDialog();
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
            MedicalRecordViewModel = new MedicalRecordViewModel(SelectedItem);
            MainViewModel.GetInstance().CurrentView = MedicalRecordViewModel;
        }
    }
}