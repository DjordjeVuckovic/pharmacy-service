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
        public AppointmentsView AppointmentsView { get; set; }
        public PatientsViewModel PatientsViewModel { get; set; }
        public RelayCommand PateintCommand { get; set; }
        private MedicineViewModel MedicineViewModel { get; set; }
        public RelayCommand MedicineCommand { get; set; }
        public DashBoardViewModel DashBoardViewModel { get; set; }
        
        
        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        /*
        public MainViewModel()
        {
            DashBoardViewModel = new DashBoardView();
            //RecordView = new RecordView();
            //AppointmentsWindow = AppointmentsWindow.GetInstance();

            CurrentView = DashBoardViewModel;
            DashCommand = new RelayCommand(o =>
                {
                    CurrentView = DashBoardViewModel;
                }
            );
            RecordCommand = new RelayCommand(o =>
                {
                    CurrentView = RecordView;
                }
            );
            AppointmentCommand = new RelayCommand(o =>
                {
                    //
                }
            );
        }*/
        private static MainViewModel _instance;

        public static MainViewModel Instance => _instance;

        public MainViewModel(string doctorJmbg)
        {
            _instance = this;
            DoctorId = doctorJmbg;
            PatientsViewModel = new PatientsViewModel();
            AppointmentsView = new AppointmentsView(doctorJmbg);
            RecordViewModel = new RecordViewModel();
            MedicineViewModel = new MedicineViewModel();
            DashBoardViewModel = new DashBoardViewModel();
            //RecordViewModel.DoctorId = doctorJmbg;

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
                    CurrentView = AppointmentsView;
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
            
        }
        
    }
}