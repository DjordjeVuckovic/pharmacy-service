using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TechHealth.Annotations;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.CRUDRooms;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for EquipmentView.xaml
    /// </summary>
    public partial class EquipmentView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Equipment> eqlist;
        private Equipment selectedItem;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand AddEquipmentCommand { get; set; }
        public RelayCommand DeleteEquipmentCommand { get; set; }
        public RelayCommand ReallocateCommand { get; set; }

        public Equipment SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Equipment> Equipment
        {
            get
            {
                return eqlist;
            }

            set
            {
                eqlist = value;
                //OnPropertyChanged();
            }
        }
        public EquipmentView()
        {
            InitializeComponent();
            DataContext = this;
            eqlist = new ObservableCollection<Equipment>(EquipmentRepository.Instance.GetAllToList());
            AddEquipmentCommand = new RelayCommand(param => ExecuteAdd());
            DeleteEquipmentCommand = new RelayCommand(param => ExecuteDelete(), param => CanExecuteDelete());
            ReallocateCommand = new RelayCommand(param => ExecuteReallocate(), param => CanExecuteReallocate());
        }
        private bool CanExecuteReallocate()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteReallocate()
        {
            new ReallocateForm(selectedItem).ShowDialog();
        }

        private bool CanExecuteDelete()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteDelete()
        {
            Equipment eq = (Equipment)dataEquipment.SelectedItem;
            EquipmentRepository.Instance.Delete(eq.id);
            Equipment.Remove(eq);
            MessageBox.Show("You have successfully deleted the equipment");
        }

        private void ExecuteAdd()
        {
            new AddEquipment(eqlist).ShowDialog();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
