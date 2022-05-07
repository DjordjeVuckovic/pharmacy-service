using System;
using System.Windows;
using System.Windows.Forms;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using MessageBox = System.Windows.MessageBox;

namespace TechHealth.DoctorView.ViewModel
{
    public class RejectViewModel:ViewModelBase
    {
        private Medicine selectedMedicine;
        private string details;
        private readonly  DoctorController doctorController = new DoctorController();
        private readonly MedicineController medicineController = new MedicineController();
        public event EventHandler OnRequestClose;
        public  RelayCommand CancelCommand { get; set;}
        

        public Medicine SelectedMedicine
        {
            get => selectedMedicine;
            set
            {
                selectedMedicine = value;
                OnPropertyChanged(nameof(SelectedMedicine));
            }
        }

        public string Details
        {
            get => details;
            set
            {
                details = value;
                OnPropertyChanged(nameof(Details));
            }
        }
        public RelayCommand FinishCommand { get; set; }
        public string DoctorName { get; set; }
        public  string MedicineName { get; set; }
        public RejectViewModel(Medicine selectedItem, string docotorId)
        {
            Doctor doctor = doctorController.GetById(docotorId);
            DoctorName = doctor.FullSpecialization;
            SelectedMedicine = selectedItem;
            MedicineName = SelectedMedicine.MedicineName;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            CancelCommand = new RelayCommand(param => CloseWindow());
        }

        private bool CanExecute()
        {
            if (Details == null)
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            SelectedMedicine.MedicineStatus = MedicineStatus.Rejected;
            medicineController.Update(SelectedMedicine);
            MessageBox.Show(@"You are successfully reject medicine: " + MedicineName);
            OnRequestClose(this, new EventArgs());
        }
        private void CloseWindow()
        {
           
                OnRequestClose(this, new EventArgs());
        }
    }
        
}