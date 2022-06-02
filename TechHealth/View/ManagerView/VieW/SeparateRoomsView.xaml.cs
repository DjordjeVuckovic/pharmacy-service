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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for SeparateRoomsView.xaml
    /// </summary>
    public partial class SeparateRoomsView : UserControl
    {
        private Room selected;
        private RoomSeparationController roomSeparationController = new RoomSeparationController();
        private RoomController roomController = new RoomController();
        public SeparateRoomsView()
        {
            InitializeComponent();
            DataContext = this;
            var rm = SeparateRoomsViewModel.Instance().getSelectedRoom();
            selected = rm;
            TxtRoomID.Text = selected.roomId;
            TxtSeparationType.Text = ManagerConversions.RoomTypesToString(selected.roomTypes);
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
            rs.RoomOne.roomTypes = ManagerConversions.StringToRoomType(TxtSeparationType.Text);
            Room roomTwo = new Room();
            roomTwo.roomId = TxtNewRoom.Text;
            roomTwo.floor = selected.floor;
            roomTwo.availability = true;
            roomTwo.roomTypes = ManagerConversions.StringToRoomType(CbType.Text);
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

            var RoomVm = new RoomViewModel();
            MainViewModel.Instance().CurrentView = RoomVm;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            var RoomVm = new RoomViewModel();
            MainViewModel.Instance().CurrentView = RoomVm;
        }
    }
}
