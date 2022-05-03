using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TechHealth.Annotations;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.CRUDRooms;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Room> rooms;

        private RoomController roomController = new RoomController();
        private Room selectedItem;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand AddRoomCommand { get; set; }
        public RelayCommand DeleteRoomCommand { get; set; }
        public RelayCommand UpdateRoomCommand { get; set; }
        public RelayCommand InventoryCommand { get; set; }
        public RelayCommand RenovationCommand { get; set; }
        public Room SelectedItem
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

        public ObservableCollection<Room> Rooms
        {
            get
            {
                return rooms;
            }

            set
            {
                rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }
        public RoomView()
        {
            InitializeComponent();
            DataContext = this;
            rooms = new ObservableCollection<Room>(RoomRepository.Instance.GetAll().Values);
            AddRoomCommand = new RelayCommand(param => ExecuteAdd(), param => CanExecuteAdd());
            DeleteRoomCommand = new RelayCommand(param => ExecuteDel(), param => CanExecuteDel());
            UpdateRoomCommand = new RelayCommand(param => ExecuteUpdate(), param => CanExecuteUpdate());
            InventoryCommand = new RelayCommand(param => ExecuteInventory(), param => CanExecuteInventory());
            RenovationCommand = new RelayCommand(param => ExecuteRenovation(), param => CanExecuteRenovation());
        }

        private bool CanExecuteRenovation()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteRenovation()
        {
            new AddRenovation(selectedItem).ShowDialog();
        }

        private bool CanExecuteInventory()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteInventory()
        {
            new RoomInventory(selectedItem).ShowDialog();
        }

        private bool CanExecuteUpdate()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteUpdate()
        {
            new UpdateForm(selectedItem).ShowDialog();
        }

        private bool CanExecuteDel()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void ExecuteDel()
        {
            roomController.Delete(selectedItem.roomId);
            rooms.Remove(selectedItem);
            MessageBox.Show("You have successfully deleted the room");
        }

        private bool CanExecuteAdd()
        {
            return true;
        }

        private void ExecuteAdd()
        {
            new AddForm(rooms).ShowDialog();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
