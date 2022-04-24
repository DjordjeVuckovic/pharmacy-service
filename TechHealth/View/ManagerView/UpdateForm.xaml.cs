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
using TechHealth.Repository;
using TechHealth.View.ManagerView;

namespace TechHealth.View.ManagerView
{
    public partial class UpdateForm : Window
    {
        private Room selected;
        private RoomController roomController = new RoomController();
        public UpdateForm(Room room)
        {
            selected = RoomRepository.Instance.GetById(room.roomId);
            InitializeComponent();

            this.DataContext = this;

            TxtRoomId.Text = selected.roomId;
            CbFloor.Text = FloorToString(selected.floor);
            CbType.Text = RoomTypesToString(selected.roomTypes);
            CbAvailability.Text = AvailabilityToString(selected.availability);
            
        }

        public string RoomTypesToString(RoomTypes type)
        {
            switch (type)
            {
                case RoomTypes.operation:
                    return "Operation";
                case RoomTypes.examination:
                    return "Examination";
                case RoomTypes.rest:
                    return "Rest";
                default:
                    return "Office";
            }
        }

        public string FloorToString(int floor)
        {
            switch (floor)
            {
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                default:
                    return "0";
            }
        }

        public string AvailabilityToString(bool availability)
        {
            if (availability)
                return "In function";
            else
                return "Not in function";
            
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
            selected.floor = StringToFloor(CbFloor.Text);
            selected.roomTypes = StringToRoomType(CbType.Text);
            selected.availability = StringToAvailability(CbAvailability.Text);

            roomController.Update(selected.roomId, selected.floor, selected.availability,selected.roomTypes);
            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
