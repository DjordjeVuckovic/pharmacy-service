using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    public partial class AddForm : Window
    {
        private Room room;
        private RoomController roomController = new RoomController();
        private ObservableCollection<Room> rooms;
        public AddForm(ObservableCollection<Room> roomList)
        {
            InitializeComponent();
            rooms = roomList;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            room = new Room();

            room.roomId = TxtRoomId.Text;
            room.floor = ManagerConversions.StringToFloor(CbFloor.Text);
            room.roomTypes = ManagerConversions.StringToRoomType(CbType.Text);
            room.availability = ManagerConversions.StringToAvailability(CbAvailability.Text);

            if (RoomRepository.Instance.WarehouseExists() && room.roomTypes == RoomTypes.warehouse)
            {
                MessageBox.Show("There can only be one warehouse!");
                this.Close();
                return;
            }
            roomController.Create(room);
            rooms.Add(room);
            this.Close();
        }
    }
}
