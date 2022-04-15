using System.Collections.ObjectModel;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.ViewModel
{
    public class RecordViewModel:ViewModelBase
    {
        private string doctorId;
        private string ics;

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
                return doctorId;
            }
            set
            {
                doctorId = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Appointment> _appointments;

        public ObservableCollection<Appointment> Appointments
        {
            get=> _appointments ?? (_appointments =
                    new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetByDoctorId(doctorId)));
            set
            {
                _appointments = value;
                OnPropertyChanged();
            }
            
        }

        private Appointment _selectedItem;

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
            DoctorId = doctorId;
            
        }
    }
}