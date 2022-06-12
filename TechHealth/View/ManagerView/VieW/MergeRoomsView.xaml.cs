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
using TechHealth.Repository;
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
        private List<string> possibleMergingRooms = new List<string>();
        public MergeRoomsView()
        {
            InitializeComponent();
            DataContext = this;
            Room rm = MergeRoomsViewModel.Instance().getSelectedRoom();
            selected = rm;
            rooms = roomController.GetRoomIDs();
            TxtRoomID.Text = selected.RoomId;

            foreach (var r in roomController.GetAll())
            {
                if (r.RoomId != selected.RoomId && r.RoomId != "Warehouse")
                {
                    possibleMergingRooms.Add(r.RoomId);
                }
            }
            CbMergeRoom.ItemsSource = possibleMergingRooms;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            RoomMerging rm = new RoomMerging();
            rm.RoomOne = selected.RoomId;
            string dateStart = RStart.Text;
            string dateStartTime = dateStart + " " + TxtStartTime.Text;
            string dateEnd = REnd.Text;
            string dateEndTime = dateEnd + " " + TxtEndTime.Text;

            try
            {
                rm.MergeStart = DateTime.Parse(dateStartTime);
                rm.MergeEnd = DateTime.Parse(dateEndTime);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid date");
                return;
            }

            rm.RoomTwo = CbMergeRoom.Text;
            rm.RoomType = ManagerConversions.StringToRoomType(CbType.Text);
            rm.MergeID = Guid.NewGuid().ToString("N");

            Room roomOne = roomController.GetRoombyId(rm.RoomOne);
            Room roomTwo = roomController.GetRoombyId(rm.RoomTwo);

            if (TxtStartTime.Text == "" || TxtEndTime.Text == "" || CbMergeRoom.Text == "" || CbType.Text == "")
            {
                MessageBox.Show("All fields have to be filled in order to proceed!");
                return;
            }

            if (roomOne.Floor != roomTwo.Floor)
            {
                MessageBox.Show("Can't perform merging because rooms aren't on the same floor");
                return;
            }
            else
            {
                if (AppointmentRepository.Instance.CanDoMerge(rm))
                {
                    AppointmentRepository.Instance.CancelAppointmentIfThereIsNoRoomAfterMerge(rm);
                    if (DateTime.Compare(DateTime.Now, rm.MergeEnd) == 0)
                    {
                        roomMergingController.MergeRooms(rm);
                    }
                    else
                    {
                        roomMergingController.Create(rm);
                    }
                }
                else
                {
                    MessageBox.Show("Can't perform merging because there is an appointment in that period!");
                    return;
                }
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
