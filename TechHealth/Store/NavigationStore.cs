using System;
using TechHealth.Core;
using TechHealth.DoctorView.ViewModel;

namespace TechHealth.Store
{
    public class NavigationStore : ViewModelBase
    {
        private object currentViewModel;
        private RelayCommand dashCommand;
        private DashBoardViewModel DashBoardViewModel { get; set; }

        public RelayCommand DashCommand
        {
            get
            {
                if (dashCommand == null)
                {
                    dashCommand = new RelayCommand(param => DashCommandExecute());
                }

                return dashCommand;
            }
        }

        private void DashCommandExecute()
        {
            DashBoardViewModel = new DashBoardViewModel();
            CurrentViewModel = DashBoardViewModel;
        }
        public object CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private static NavigationStore _instance = null;
        public static NavigationStore GetInstance(string id)
        {
            if (_instance == null)
                _instance = new NavigationStore(id);
            return _instance;
        }

        private NavigationStore(string id)
        {
            if (id.Equals("1"))
            {

            }

        }

        public event Action CurrentViewModelChanged;
    }
}
