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
using TechHealth.Conversions;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;

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
            AddRoomCommand = new RelayCommand(param => Execute(), param => CanExecute());
            DeleteRoomCommand = new RelayCommand(param => Execute1(), param => CanExecute1());
        }

        private bool CanExecute1()
        {
            if (selectedItem == null)
            {
                return false;
            }

            return true;
        }

        private void Execute1()
        {
            roomController.Delete(selectedItem.roomId);
            rooms.Remove(selectedItem);
            MessageBox.Show("You have successfully deleted the room");
        }

        private bool CanExecute()
        {
            return true;
        }

        private void Execute()
        {
            //prescriptionWindow = new PrescriptionWindow(selectedItem);
            //prescriptionWindow.ShowDialog();

            //test da li radi add room preko komande
            Room room = new Room
            {
                roomId = "102",
                floor = 2,
                availability = true,
                roomTypes = RoomTypes.office,
                equipment = new List<Equipment>()
            };
            roomController.Create(room);
            rooms.Add(room);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
