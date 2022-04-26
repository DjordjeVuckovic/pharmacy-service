using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Core;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand EquipmentViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public EquipmentViewModel EquipmentVm { get; set; }

        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            EquipmentVm = new EquipmentViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            EquipmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = EquipmentVm;
            });


        }
    }
}
