using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class UpdateMedViewModel
    {
        private Medicine selected;

        private static UpdateMedViewModel _instance;

        public static UpdateMedViewModel Instance()
        {
            return _instance;
        }
        public UpdateMedViewModel(Medicine med)
        {
            _instance = this;
            selected = med;
        }

        public Medicine getSelectedMed()
        {
            return selected;
        }
    }
}
