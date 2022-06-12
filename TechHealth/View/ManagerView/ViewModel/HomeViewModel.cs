using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Core;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class HomeViewModel
    {
        public RelayCommand RoomViewCommand { get; set; }
        public RelayCommand HelpViewCommand { get; set; }

        public HomeViewModel()
        {
            RoomViewCommand = new RelayCommand(o =>
            {
                var RoomVm = new RoomViewModel();
                MainViewModel.Instance().CurrentView = RoomVm;
            });

            HelpViewCommand = new RelayCommand(o =>
            {
                var HelpVm = new HelpViewModel();
                MainViewModel.Instance().CurrentView = HelpVm;
            });
        }
    }
}
