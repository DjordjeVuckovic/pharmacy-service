using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class UpdateEquipmentViewModel
    {
        private Equipment selected;

        private static UpdateEquipmentViewModel _instance;

        public static UpdateEquipmentViewModel Instance()
        {
            return _instance;
        }
        public UpdateEquipmentViewModel(Equipment eq)
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
