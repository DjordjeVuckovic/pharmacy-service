using System.Collections.ObjectModel;
using TechHealth.Core;
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
        private TherapyWindow therapyWindow;
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
            medicines = new ObservableCollection<Medicine>(MedicineRepository.Instance.DictionaryValuesToList());
            //TherapyCommand= new RelayCommand(param => Execute(), param => CanExecute());
            //MedicineRecordCommand = new RelayCommand(param => Execute1(), param => CanExecute1());
        }

        private bool CanExecute()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void Execute()
        {
            //therapyWindow = new TherapyWindow(selectedItem);
            therapyWindow.ShowDialog();
        }
        private bool CanExecute1()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }
    }
}