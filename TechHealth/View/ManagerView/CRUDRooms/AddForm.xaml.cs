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

namespace TechHealth.View.ManagerView.CRUDRooms
{
    public partial class AddForm : Window
    {
        private Room room;
        private RoomController roomController = new RoomController();
        public AddForm()
        {
            InitializeComponent();
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
            room.equipment = new List<Equipment>
                {
                    new Equipment
                    {
                        name = "bandazer",
                        id = "1",
                        type = EquipmentType.statical,
                        quantity = 30,
                        roomID = "sobica"
                    },

                    new Equipment
                    {
                        name = "gaze",
                        id = "2",
                        type = EquipmentType.statical,
                        quantity = 80,
                        roomID = "sobaa"
                    },
                };

            //roomController.Create(room.roomId, room.floor, room.availability, room.roomTypes);
            roomController.Create(room);


            this.Close();
        }       
    }
}
