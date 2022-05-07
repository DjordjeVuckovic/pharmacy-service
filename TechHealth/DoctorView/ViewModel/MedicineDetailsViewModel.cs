using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class MedicineDetailsViewModel:ViewModelBase
    {
        public string MedicineId{ get; set; }
        public string Composition{ get; set; }
        public string Quantity{ get; set; }
        public string Units{ get; set; }
        public string SideEffects{ get; set; }
        public string MainSubstance { get; set; }
        public string Price{ get; set; }
        public string MedicineName{ get; set; }

        public string MedicineStatus { get; set; }
        private  Medicine SelectedMedicine { get; set; }
        public string MedicineNameD { get; set; }
        public MedicineDetailsViewModel(Medicine selectedItem)
        {
            SelectedMedicine = selectedItem;
            MedicineId = "Medicine id:  " + SelectedMedicine.MedicineId;
            MainSubstance = "Main substance:  " + SelectedMedicine.MainSubstance.SubstanceName;
            Composition = "Composition: " + SelectedMedicine.MedicineSubstances;
            Quantity = "Quantity:  " + SelectedMedicine.Quantity;
            Units = "Units: " + SelectedMedicine.Units;
            SideEffects = "SideEffects:  " + SelectedMedicine.SideEffects;
            Price = "Price:  " + SelectedMedicine.Price;
            MedicineName = "Medicine name: " + SelectedMedicine.MedicineName;
            MedicineStatus = "Medicine status: " + SelectedMedicine.MedicineStatusToString();
            MedicineNameD = SelectedMedicine.MedicineName;
        }
    }
}