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


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModelP();
            AppointmentVm = new AppointmentViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            AppointmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = AppointmentVm;
            });
        }

    }
}
