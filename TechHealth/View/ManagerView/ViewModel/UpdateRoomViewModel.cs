using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class UpdateRoomViewModel
    {
        private Room selected;

        private static UpdateRoomViewModel _instance;

        public static UpdateRoomViewModel Instance()
        {
            return _instance;
        }
        public UpdateRoomViewModel(Room rm)
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
