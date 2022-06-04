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

            room.RoomId = TxtRoomId.Text;
            room.Floor = ManagerConversions.StringToFloor(CbFloor.Text);
            room.RoomTypes = ManagerConversions.StringToRoomType(CbType.Text);
            room.Availability = ManagerConversions.StringToAvailability(CbAvailability.Text);

            if (roomController.WarehouseExists() && room.RoomTypes == RoomTypes.warehouse)
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
