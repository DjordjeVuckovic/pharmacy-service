using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.Windows;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.ViewModel
{
    public class MedicineViewModel:ViewModelBase
    {
        private ObservableCollection<Medicine> medicines;
        private Medicine selectedItem;
        private PrescriptionWindow prescriptionWindow;
        private  readonly  MedicineController medicineController = new MedicineController();
        public  RelayCommand ApproveCommand { get; set; }
        public  RelayCommand RejectCommand { get; set; }
        public RelayCommand DetailsCommand { get; set; }
        private string DocotorId;
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

        public MedicineViewModel(string doctorId)
        {
            DocotorId = doctorId;
            Medicines = medicineController.GetAll();
            //PrescribeCommand= new RelayCommand(param => Execute(), param => CanExecute());
            ApproveCommand = new RelayCommand(param=>ExecuteApprove(),param=>CanExecuteApprove());
            RejectCommand = new RelayCommand(param => ExecuteReject(), param => CanExecuteReject());
            DetailsCommand = new RelayCommand(param => ExecuteDetails(), param => CanExecuteDetails());
        }

        private bool CanExecuteReject()
        {
            if (selectedItem == null || SelectedItem.MedicineStatus != MedicineStatus.Waiting)
            {
                return false;
            }

            return true;
        }

        private void ExecuteReject()
        {
            var vm = new RejectViewModel(SelectedItem,DocotorId);
            RejectWindow rejectWindow = new RejectWindow()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => rejectWindow.Close();

            rejectWindow.ShowDialog();
        }
        private bool CanExecuteApprove()
        {
            if (selectedItem == null || SelectedItem.MedicineStatus != MedicineStatus.Waiting)
            {
                return false;
            }

            return true;
        }

        private void ExecuteApprove()
        {
            SelectedItem.MedicineStatus= MedicineStatus.Approved;
            medicineController.Update(SelectedItem);
            MessageBox.Show(@"Yor are successfully approve medicine: " + SelectedItem.MedicineName);
        }
        private bool CanExecuteDetails()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteDetails()
        {
            var vm = new MedicineDetailsViewModel(SelectedItem);
            MainViewModel.GetInstance().CurrentView = vm;
        }
        
    }
}