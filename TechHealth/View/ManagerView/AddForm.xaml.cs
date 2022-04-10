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

namespace TechHealth.View.ManagerView
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

        public RoomTypes StringToRoomType(string str)
        {
            switch (str)
            {
                case "Operation":
                    return RoomTypes.operation;
                case "Examination":
                    return RoomTypes.examination;
                case "Rest":
                    return RoomTypes.rest;
                default:
                    return RoomTypes.office;
            }
        }

        public int StringToFloor(string str)
        {
            switch (str)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                default:
                    return 0;
            }
        }

        public bool StringToAvailability(string str)
        {
            return str.Equals("In function");
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
             room = new Room();

            room.roomId = TxtRoomId.Text;
            room.floor = StringToFloor(CbFloor.Text);
            room.roomTypes = StringToRoomType(CbType.Text);
            room.availability = StringToAvailability(CbAvailability.Text);

            roomController.Create(room.roomId, room.floor, room.availability, room.roomTypes);

            //ManagerMainWindow mmw = new ManagerMainWindow().Show();

            this.Close();
        }       
    }
}
