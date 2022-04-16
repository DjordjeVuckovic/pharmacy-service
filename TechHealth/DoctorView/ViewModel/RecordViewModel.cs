using System.Collections.ObjectModel;
using TechHealth.Core;
using TechHealth.DoctorView.MedicalHistory;
using TechHealth.DoctorView.View;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.ViewModel
{
    public class RecordViewModel:ViewModelBase
    {
        private string _doctorId;
        private string ics;
        private object _currentView;
        private static RecordViewModel _instance;
        public RelayCommand NewCommand { get; set; }
        public NewAnamnesis AddAnamnesisView { get; set; }
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public string Ics
        {
            get
            {
                return ics;
            }
            set
            {
                ics = value;
                OnPropertyChanged();
            }
        }
        
        public string DoctorId
        {
            get
            {
                return _doctorId;
            }
            set
            {
                _doctorId = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Appointment> _appointments;

        public ObservableCollection<Appointment> Appointments
        {
            get
            {
                return _appointments;
            }
            set
            {
                _appointments = value;
                OnPropertyChanged();
            }
            
        }

        private Appointment _selectedItem;

        public static RecordViewModel GetInstance()
        {
            return _instance;
        }
        public Appointment SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
           
        public RecordViewModel(string doctorId)
        {
            _doctorId = doctorId;
            _instance = this;
            _appointments = new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetByDoctorId(_doctorId));
            NewCommand = new RelayCommand(param => Execute(), param => CanExecute());
            
        }

        private bool CanExecute()
        {
            if (SelectedItem == null || SelectedItem.Evident)
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            AddAnamnesisView = new NewAnamnesis(_selectedItem);
            AddAnamnesisView.ShowDialog();
        }
        
    }
}