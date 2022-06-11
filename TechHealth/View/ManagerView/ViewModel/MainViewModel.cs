using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Core;
using MessageBox = System.Windows.Forms.MessageBox;
using Application = System.Windows.Forms.Application;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }
        public RelayCommand EquipmentViewCommand { get; set; }
        public RelayCommand RoomViewCommand { get; set; }
        public RelayCommand MedicineViewCommand { get; set; }
        public RelayCommand SurveyViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public EquipmentViewModel EquipmentVm { get; set; }
        public RoomViewModel RoomVm { get; set; }
        public MedViewModel MedVm { get; set; }
        public SurveyViewModel SurveyVm { get; set; }

        private static MainViewModel _instance;

        public static MainViewModel Instance()
        {
            return _instance;
        }

        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            _instance = this;
            HomeVm = new HomeViewModel();
            EquipmentVm = new EquipmentViewModel();
            RoomVm = new RoomViewModel();
            MedVm = new MedViewModel();
            SurveyVm = new SurveyViewModel();

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

            MedicineViewCommand = new RelayCommand(o =>
            {
                CurrentView = MedVm;
            });

            SurveyViewCommand = new RelayCommand(o =>
            {
                CurrentView = SurveyVm;
            });

            LogoutCommand = new RelayCommand(o =>
            {
                DialogResult dialogResult = MessageBox.Show(@"Are you sure about that?", @"Logout", MessageBoxButtons.YesNo);
                if (dialogResult == (DialogResult)MessageBoxResult.Yes)
                {
                    new LoginWindow().ShowDialog();
                }
            });
        }
    }
}
