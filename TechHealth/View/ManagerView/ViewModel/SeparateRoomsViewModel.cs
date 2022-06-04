using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class SeparateRoomsViewModel
    {
        private Room selected;

        private static SeparateRoomsViewModel _instance;

        public static SeparateRoomsViewModel Instance()
        {
            return _instance;
        }
        public SeparateRoomsViewModel(Room rm)
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
