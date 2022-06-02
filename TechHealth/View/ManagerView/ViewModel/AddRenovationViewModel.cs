using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class AddRenovationViewModel
    {
        private Room selected;

        private static AddRenovationViewModel _instance;

        public static AddRenovationViewModel Instance()
        {
            return _instance;
        }
        public AddRenovationViewModel(Room rm)
        {
            _instance = this;
            selected = rm;
        }

        public Room getSelectedRoom()
        {
            return selected;
        }
    }
}
