using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechHealth.Annotations;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.CRUDRooms;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for EquipmentView.xaml
    /// </summary>
    public partial class EquipmentView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Equipment> eqlist;
        private Equipment selectedItem;
        private string type;
        private EquipmentController equipmentController = new EquipmentController();
        private RoomEquipmentController roomEquipmentController = new RoomEquipmentController();
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand AddEquipmentCommand { get; set; }
        public RelayCommand DeleteEquipmentCommand { get; set; }
        public RelayCommand ReallocateCommand { get; set; }
        public RelayCommand ViewEquipmentCommand { get; set; }

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
            ViewEquipmentCommand = new RelayCommand(param => ExecuteView(), param => CanExecuteView());
        }

        private bool CanExecuteView()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteView()
        {
            new UpdateEquipment(selectedItem).ShowDialog();
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
            equipmentController.Delete(eq.id);
            Equipment.Remove(eq);
            List<RoomEquipment> reList = roomEquipmentController.GetRoomEqListByEqName(eq.name);
            roomEquipmentController.DeleteRoomEqByEqName(reList);
            MessageBox.Show("You have successfully deleted the equipment");
        }

        private void ExecuteAdd()
        {
            //new AddEquipment(eqlist).ShowDialog();
            var AddEqVm = new AddEquipmentViewModel();
            MainViewModel.Instance().CurrentView = AddEqVm;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //eqlist = new ObservableCollection<Equipment>();
            eqlist.Clear();

            if (search.Text.Equals(""))
            {
                foreach (var eq in equipmentController.GetAllToList())
                {
                    eqlist.Add(eq);
                }
            }
            else
            {
                foreach (var eq in equipmentController.GetAllToList())
                {
                    if (eq.name.ToLower().Contains(search.Text.ToLower()) || eq.quantity.ToString().ToLower().Contains(search.Text.ToLower()) || eq.id.ToLower().Contains(search.Text.ToLower()) || eq.type.ToString().ToLower().Contains(search.Text.ToLower()))
                    {
                        eqlist.Add(eq);
                    }
                }
            }
            //dataEquipment.ItemsSource = eqlist;
        }

        private void CbType_DropDownClosed(object sender, EventArgs e)
        {
            type = CbType.Text;
            if (type.Equals("Statical"))
            {
                eqlist = new ObservableCollection<Equipment>(equipmentController.GetEquipmentByEqType(EquipmentType.statical));
            }
            else if (type.Equals("Dynamical"))
            {
                eqlist = new ObservableCollection<Equipment>(equipmentController.GetEquipmentByEqType(EquipmentType.dynamical));
            }
            else
            {
                eqlist = new ObservableCollection<Equipment>(equipmentController.GetAllToList());
            }
            dataEquipment.ItemsSource = eqlist;
        }
    }
}
