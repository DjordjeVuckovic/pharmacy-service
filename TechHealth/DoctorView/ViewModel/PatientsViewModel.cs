using System.Collections.ObjectModel;
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
        public RelayCommand RecordCommand { get; set; }
        private ObservableCollection<Patient> patients;
        private Patient selectedItem;
        private TherapyWindow therapyWindow;
        private  object currentViewPatient;
        public string DoctorId { get; set; }
        public object CurrentViewPatient
        {
            get => currentViewPatient;
            set
            {
                currentViewPatient = value;
                OnPropertyChanged(nameof(currentViewPatient));
            }
        }
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
            patients = new ObservableCollection<Patient>(PatientRepository.Instance.DictionaryValuesToList());
            TherapyCommand= new RelayCommand(param => Execute(), param => CanExecute());
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
            therapyWindow = new TherapyWindow(selectedItem);
            therapyWindow.ShowDialog();
        }
    }
}