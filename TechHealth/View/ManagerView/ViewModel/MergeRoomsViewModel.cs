using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class MergeRoomsViewModel
    {
        private Room selected;

        private static MergeRoomsViewModel _instance;

        public static MergeRoomsViewModel Instance()
        {
            return _instance;
        }
        public MergeRoomsViewModel(Room rm)
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
