using System.Collections.ObjectModel;
using TechHealth.Controller;
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
        private readonly AppointmentController appointmentController = new AppointmentController();
        private object _currentView;
        private static RecordViewModel _instance;
        public RelayCommand NewCommand { get; set; }
        public RelayCommand ReviewCommand { get; set; }
        public NewAnamnesis AddAnamnesisView { get; set; }
        public ReviewAnamnesis ReviewAnamnesis { get; set; }
        
        public string DoctorId
        {
            get
            {
                return _doctorId;
            }
            set
            {
                _doctorId = value;
                OnPropertyChanged(nameof(DoctorId));
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
                OnPropertyChanged(nameof(Appointments));
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
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
           
        public RecordViewModel()
        {
            _doctorId = LoginWindow.GetDoctorId();
            _instance = this;
            Appointments = new ObservableCollection<Appointment>(appointmentController.GetByDoctorId(_doctorId));
            NewCommand = new RelayCommand(param => Execute(), param => CanExecute());
            ReviewCommand = new RelayCommand(param => Execute1(), param => CanExecute1());

        }

        public void RefreshView()
        {
            Appointments.Clear();
            Appointments=new ObservableCollection<Appointment>(appointmentController.GetByDoctorId(_doctorId));
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
        private bool CanExecute1()
        {
            if (SelectedItem == null || !SelectedItem.Evident)
            {
                return false;
            }

            return true;
        }

        private void Execute1()
        {
            ReviewAnamnesis = new ReviewAnamnesis(_selectedItem);
            ReviewAnamnesis.ShowDialog();
        }
        
    }
}