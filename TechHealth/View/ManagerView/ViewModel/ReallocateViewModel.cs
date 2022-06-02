using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class ReallocateViewModel
    {
        private Equipment selected;

        private static ReallocateViewModel _instance;

        public static ReallocateViewModel Instance()
        {
            return _instance;
        }
        public ReallocateViewModel(Equipment eq)
        {
            _instance = this;
            selected = eq;
        }

        public Equipment getSelectedEquipment()
        {
            return selected;
        }
    }
}
