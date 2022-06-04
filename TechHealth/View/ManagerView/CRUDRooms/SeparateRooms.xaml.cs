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
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for SeparateRooms.xaml
    /// </summary>
    public partial class SeparateRooms : Window
    {
        private Room selected;
        private RoomSeparationController roomSeparationController = new RoomSeparationController();
        private RoomController roomController = new RoomController();
        public SeparateRooms(Room rm)
        {
            InitializeComponent();
            DataContext = this;
            selected = rm;
            TxtRoomID.Text = selected.RoomId;
            TxtSeparationType.Text = ManagerConversions.RoomTypesToString(selected.RoomTypes);
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            RoomSeparation rs = new RoomSeparation();
            string dateStart = RStart.Text;
            string dateStartTime = dateStart + " " + TxtStartTime.Text;
            rs.SeparationStart = DateTime.Parse(dateStartTime);
            string dateEnd = REnd.Text;
            string dateEndTime = dateEnd + " " + TxtEndTime.Text;
            rs.SeparationEnd = DateTime.Parse(dateEndTime);
            rs.RoomOne = selected;
            rs.RoomOne.RoomTypes = ManagerConversions.StringToRoomType(TxtSeparationType.Text);
            Room roomTwo = new Room();
            roomTwo.RoomId = TxtNewRoom.Text;
            roomTwo.Floor = selected.Floor;
            roomTwo.Availability = true;
            roomTwo.RoomTypes = ManagerConversions.StringToRoomType(CbType.Text);
            rs.RoomTwo = roomTwo;
            rs.SeparationID = Guid.NewGuid().ToString("N");

            //if (DateTime.Compare(DateTime.Now, rs.SeparationEnd) == 0)
            //{
            //    roomController.Create(roomTwo);
            //    roomController.Update(rs.RoomOne);
            //    roomSeparationController.SeparateRooms(rs);               
            //}
            //else
            //{
            //    roomSeparationController.Create(rs);
            //}
            roomController.Create(roomTwo);
            roomController.Update(rs.RoomOne);
            roomSeparationController.Create(rs);
            roomSeparationController.SeparateRooms(rs);

            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
