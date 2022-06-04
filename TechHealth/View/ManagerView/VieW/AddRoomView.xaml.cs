using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechHealth.Model;
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.View.ManagerView.VieW;
using TechHealth.Repository;
using System.Collections.ObjectModel;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for AddRoomView.xaml
    /// </summary>
    public partial class AddRoomView : UserControl
    {
        private Room room;
        private RoomController roomController = new RoomController();
        //private ObservableCollection<Room> rooms;
        public AddRoomView(/*ObservableCollection<Room> roomList*/)
        {
            InitializeComponent();
            //DataContext = new AddRoomViewModel();
            //rooms = roomList;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            var RoomVm = new RoomViewModel();
            MainViewModel.Instance().CurrentView = RoomVm;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            room = new Room();
            var RoomVm = new RoomViewModel();

            room.RoomId = TxtRoomId.Text;
            room.Floor = ManagerConversions.StringToFloor(CbFloor.Text);
            room.RoomTypes = ManagerConversions.StringToRoomType(CbType.Text);
            room.Availability = ManagerConversions.StringToAvailability(CbAvailability.Text);

            if (roomController.WarehouseExists() && room.RoomTypes == RoomTypes.warehouse)
            {
                MessageBox.Show("There can only be one warehouse!");
                MainViewModel.Instance().CurrentView = RoomVm;
                return;
            }
            roomController.Create(room);
            //rooms.Add(room);
            MainViewModel.Instance().CurrentView = RoomVm;
        }
    }
}
