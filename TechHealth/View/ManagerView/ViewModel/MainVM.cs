using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Core;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class MainVM : ViewModelBase
    {
        public HomeViewModel HomeVm { get; set; }
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

        public MainVM()
        {
                HomeVm = new HomeViewModel();
                CurrentView = HomeVm;
        }
    }
}
