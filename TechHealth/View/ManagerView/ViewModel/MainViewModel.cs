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
        public RelayCommand RoomViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public EquipmentViewModel EquipmentVm { get; set; }
        public RoomViewModel RoomVm { get; set; }

        //private static MainViewModel _instance;

        //public static MainViewModel Instance()
        //{
        //    return _instance;
        //}

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
            //_instance = this;
            HomeVm = new HomeViewModel();
            EquipmentVm = new EquipmentViewModel();
            RoomVm = new RoomViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            EquipmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = EquipmentVm;
            });

            RoomViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomVm;
            });


        }
    }
}
