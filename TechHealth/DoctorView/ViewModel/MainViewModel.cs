using System;
using TechHealth.Core;
using TechHealth.DoctorView.View;

namespace TechHealth.DoctorView.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private object currentView;
        public RecordViewModel RecordViewModel { get; set; }
        public RelayCommand DashCommand { get; set; }
        public RelayCommand RecordCommand { get; set; }
        public RelayCommand AppointmentCommand { get; set; }
        public static string DoctorId { get; set; }
        private ViewModelAppointment ViewModelAppointment { get; set; }
        private PatientsViewModel PatientsViewModel { get; set; }
        public RelayCommand PateintCommand { get; set; }
        private MedicineViewModel MedicineViewModel { get; set; }
        public RelayCommand MedicineCommand { get; set; }
        public RelayCommand AccountCommand { get; set; }
        public RelayCommand HelpCommand { get; set; }
        public RelayCommand NotificationCommand { get; set; }
        private DashBoardViewModel DashBoardViewModel { get; set; }
        private AccountViewModel AccountViewModel { get; set; }
        private NotificationView NotificationView { get; set; }
        private HelpView HelpView { get; set; }
        
        
        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        private static MainViewModel _instance;

        public static MainViewModel GetInstance(string doctorId)
        {
            if (_instance == null)
            {
                DoctorId = doctorId;
                _instance = new MainViewModel();
            }
            return _instance;
        }

        public static MainViewModel GetInstance()
        {
            return _instance;
        }
        private MainViewModel()
        {
            PatientsViewModel = new PatientsViewModel();
            RecordViewModel = new RecordViewModel(DoctorId);
            MedicineViewModel = new MedicineViewModel(DoctorId);
            DashBoardViewModel = new DashBoardViewModel();
            ViewModelAppointment = new ViewModelAppointment(DoctorId);
            AccountViewModel = new AccountViewModel(DoctorId);
            HelpView = new HelpView();
            NotificationView = new NotificationView();

            CurrentView = DashBoardViewModel;
            DashCommand = new RelayCommand(o =>
                {
                    CurrentView = DashBoardViewModel;
                }
            );
            RecordCommand = new RelayCommand(o =>
                {
                    CurrentView = RecordViewModel;
                    
                }
            );
            AppointmentCommand = new RelayCommand(o =>
                {
                    CurrentView = ViewModelAppointment;
                }
            );
            PateintCommand = new RelayCommand(o =>
            {
                CurrentView = PatientsViewModel;
            });
            MedicineCommand= new RelayCommand(o =>
                {
                    CurrentView = MedicineViewModel;
                }
            );
            AccountCommand= new RelayCommand(o =>
                {
                    CurrentView = AccountViewModel;
                }
            );
            HelpCommand= new RelayCommand(o =>
                {
                    CurrentView = HelpView;
                }
            );
            NotificationCommand = new RelayCommand(o =>
                {
                    CurrentView = NotificationView;
                }
            );
            
            
        }
        
    }
}