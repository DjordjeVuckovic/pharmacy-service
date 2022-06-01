using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class RejectReasonViewModel
    {
        private Medicine medicine;
        private RejectedMedicine rejectedMedicine;
        private RejectedMedicineController rejectedMedicineController = new RejectedMedicineController();

        public RelayCommand CloseCommand { get; set; }
        public string RejectedMedicineId { get; set; }
        public string Medicine { get; set; }
        public string Reason { get; set; }
        public string Doctor { get; set; }
        public RejectReasonViewModel(Medicine med)
        {
            CloseCommand = new RelayCommand(param => ExecuteClose());
            medicine = med;
            rejectedMedicine = rejectedMedicineController.GetByMedicineId(medicine.MedicineId);

            RejectedMedicineId = "Id:   " + rejectedMedicine.RejectedMedicineId;
            Medicine = "Medicine name:  " + medicine.MedicineName;
            Reason = "Reject reason:  " + rejectedMedicine.Reason;
            Doctor = "Doctor name:  " + rejectedMedicine.Doctor.Name;
        }

        private void ExecuteClose()
        {
            var MedVm = new MedViewModel();
            MainViewModel.Instance().CurrentView = MedVm;
        }
    }
}
