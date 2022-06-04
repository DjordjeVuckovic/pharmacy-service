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
    /// Interaction logic for MergeRoomsView.xaml
    /// </summary>
    public partial class MergeRoomsView : UserControl
    {
        private List<String> rooms;
        private Room selected;
        private RoomMergingController roomMergingController = new RoomMergingController();
        private RoomController roomController = new RoomController();
        public MergeRoomsView()
        {
            InitializeComponent();
            DataContext = this;
            Room rm = MergeRoomsViewModel.Instance().getSelectedRoom();
            selected = rm;
            rooms = roomController.GetRoomIDs();
            TxtRoomID.Text = selected.RoomId;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            RoomMerging rm = new RoomMerging();
            rm.RoomOne = selected.RoomId;
            string dateStart = RStart.Text;
            string dateStartTime = dateStart + " " + TxtStartTime.Text;
            rm.MergeStart = DateTime.Parse(dateStartTime);
            string dateEnd = REnd.Text;
            string dateEndTime = dateEnd + " " + TxtEndTime.Text;
            rm.MergeEnd = DateTime.Parse(dateEndTime);
            rm.RoomTwo = TxtMergeRoom.Text;
            rm.RoomType = ManagerConversions.StringToRoomType(CbType.Text);
            rm.MergeID = Guid.NewGuid().ToString("N");

            Room roomOne = roomController.GetRoombyId(rm.RoomOne);
            Room roomTwo = roomController.GetRoombyId(rm.RoomTwo);

            if (roomOne.Floor != roomTwo.Floor)
            {
                MessageBox.Show("Can't perform merging because rooms aren't on the same floor");
                return;
            }
            else
            {
                if (DateTime.Compare(DateTime.Now, rm.MergeEnd) == 0)
                {
                    roomMergingController.MergeRooms(rm);
                }
                else
                {
                    roomMergingController.Create(rm);
                }
                //roomMergingController.Create(rm);
                //roomMergingController.MergeRooms(rm);
            }
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
