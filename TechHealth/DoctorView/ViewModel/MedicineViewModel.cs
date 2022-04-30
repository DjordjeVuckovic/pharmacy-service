using System.Collections.ObjectModel;
using TechHealth.Core;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.Windows;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.ViewModel
{
    public class MedicineViewModel:ViewModelBase
    {
        public RelayCommand PrescribeCommand { get; set; }
        private ObservableCollection<Medicine> medicines;
        private Medicine selectedItem;
        private PrescriptionWindow prescriptionWindow;
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
            get
            {
                return medicines;
            }
            set
            {
                medicines = value;
                OnPropertyChanged(nameof(Medicines));
            }
        }

        public MedicineViewModel()
        {
            
            medicines = new ObservableCollection<Medicine>(MedicineRepository.Instance.GetAllToList());
            PrescribeCommand= new RelayCommand(param => Execute(), param => CanExecute());
        }

        private bool CanExecute()
        {
            if (selectedItem == null || !SelectedItem.Approved)
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            prescriptionWindow = new PrescriptionWindow(selectedItem);
            prescriptionWindow.ShowDialog();
        }
    }
}