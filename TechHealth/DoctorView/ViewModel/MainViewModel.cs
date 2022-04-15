using TechHealth.Core;

namespace TechHealth.DoctorView.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private object _currentView;
        public DashBoardViewModel DashBoardViewModel { get; set; }
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            DashBoardViewModel = new DashBoardViewModel();
        }
    }
}