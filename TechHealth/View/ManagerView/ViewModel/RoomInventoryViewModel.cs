using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class RoomInventoryViewModel
    {
        private Room selected;

        private static RoomInventoryViewModel _instance;

        public static RoomInventoryViewModel Instance()
        {
            return _instance;
        }
        public RoomInventoryViewModel(Room rm)
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
