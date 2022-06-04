using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.CRUDRooms;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class MedViewModel : ViewModelBase
    {
        private ObservableCollection<Medicine> medicines;
        private Medicine selectedItem;
        private readonly MedicineController medicineController = new MedicineController();
        public RelayCommand AddMedicineCommand { get; set; }
        public RelayCommand UpdateMedicineCommand { get; set; }
        public RelayCommand DeleteMedicineCommand { get; set; }
        public RelayCommand RejectReasonCommand { get; set; }

        public Medicine SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<Medicine> Medicines
        {
            get => medicines;
            set
            {
                medicines = value;
                OnPropertyChanged(nameof(Medicines));
            }
        }

        public MedViewModel()
        {
            Medicines = new ObservableCollection<Medicine>(MedicineRepository.Instance.GetAllToList());
            AddMedicineCommand = new RelayCommand(param => ExecuteAdd(), param => CanExecuteAdd());
            UpdateMedicineCommand = new RelayCommand(param => ExecuteUpdate(), param => CanExecuteUpdate());
            DeleteMedicineCommand = new RelayCommand(param => ExecuteDelete(), param => CanExecuteDelete());
            RejectReasonCommand = new RelayCommand(param => ExecuteRejectReason(), param => CanExecuteRejectReason());
        }

        private bool CanExecuteRejectReason()
        {
            if (selectedItem == null || selectedItem.MedicineStatus != MedicineStatus.Rejected)
            {
                return false;
            }

            return true;
        }

        private void ExecuteRejectReason()
        {
            var RejectReasonVm = new RejectReasonViewModel(selectedItem);
            MainViewModel.Instance().CurrentView = RejectReasonVm;
        }

        private bool CanExecuteDelete()
        {
            if (selectedItem == null || selectedItem.MedicineStatus == MedicineStatus.Approved)
            {
                return false;
            }

            return true;
        }

        private void ExecuteDelete()
        {
            medicineController.Delete(selectedItem);
            medicines.Remove(selectedItem);
            //if (selectedItem.MedicineStatus == MedicineStatus.Rejected)
            //{
            //    RejectedMedicine rm = RejectedMedicineRepository.Instance.GetByMedicineId(selectedItem.MedicineId);
            //    RejectedMedicineRepository.Instance.Delete(rm.RejectedMedicineId);
            //}
            MessageBox.Show("You have successfully deleted the medicine!");
        }

        private bool CanExecuteUpdate()
        {
            if (selectedItem == null || selectedItem.MedicineStatus != MedicineStatus.Rejected)
            {
                return false;
            }

            return true;
        }

        private void ExecuteUpdate()
        {
            //new UpdateMedWindow(selectedItem).ShowDialog();
            var UpdateMedVm = new UpdateMedViewModel(selectedItem);
            MainViewModel.Instance().CurrentView = UpdateMedVm;
        }

        private bool CanExecuteAdd()
        {
            return true;
        }

        private void ExecuteAdd()
        {
            var AddMedVm = new AddMedViewModel();
            MainViewModel.Instance().CurrentView = AddMedVm;
            //new AddMedWindow(medicines).ShowDialog();
        }
    }
}
