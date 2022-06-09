using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Core;

namespace TechHealth.View.PatientView.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand HomeViewCommand { get; set; }
        public HomeViewModelP HomeVm { get; set; }
        public RelayCommand AppointmentViewCommand { get; set; }
        public AppointmentViewModel AppointmentVm { get; set; }
        public RelayCommand AppointmentHistoryViewCommand { get; set; }
        public AppointmentHistoryViewModel AppointmentHistoryVm { get; set; }
        //public RelayCommand AppointmentHistoryRateCommand { get; set; }
        public RateHospitalViewModel RateHospitalVm { get; set; }
        public RelayCommand RateHospitalCommand { get; set; }
        public MedicalRecordViewModel MedRecVm { get; set; }
        public RelayCommand MedRecCommand { get; set; }
        public static string PatientId { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private static MainViewModel _instance;

        public static MainViewModel GetInstance(string patientId)
        {
            if (_instance == null)
            {
                PatientId = patientId;
                _instance = new MainViewModel();
            }
            return _instance;
        }

        public static MainViewModel GetInstance()
        {
            return _instance;
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModelP();
            AppointmentVm = new AppointmentViewModel();
            AppointmentHistoryVm = new AppointmentHistoryViewModel();
            RateHospitalVm = new RateHospitalViewModel();
            MedRecVm = new MedicalRecordViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            AppointmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = AppointmentVm;
            });

            AppointmentHistoryViewCommand = new RelayCommand(o =>
            {
                CurrentView = AppointmentHistoryVm;
            });

            RateHospitalCommand = new RelayCommand(o =>
            {
                CurrentView = RateHospitalVm;
            });

            MedRecCommand = new RelayCommand(o =>
            {
                CurrentView = MedRecVm;
            });

        }

        



    }
}
