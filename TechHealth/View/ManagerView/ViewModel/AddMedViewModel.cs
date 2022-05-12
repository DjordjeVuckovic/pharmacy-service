using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class AddMedViewModel
    {
        public RelayCommand ConfirmCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        public AddMedViewModel()
        {
            ConfirmCommand = new RelayCommand(param => ExecuteConfirm(), param => CanExecuteConfirm());
        }

        private bool CanExecuteConfirm()
        {
            return true;
        }

        private void ExecuteConfirm()
        {
            Medicine med = new Medicine();
            med.MedicineId = Guid.NewGuid().ToString("N");
        }
    }
}
