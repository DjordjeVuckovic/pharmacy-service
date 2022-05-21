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
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for MergeRooms.xaml
    /// </summary>
    public partial class MergeRooms : Window
    {
        private List<String> rooms;
        private Room selected;
        private RoomMergingController roomMergingController = new RoomMergingController();
        public MergeRooms(Room rm)
        {
            InitializeComponent();
            DataContext = this;
            selected = rm;
            rooms = RoomRepository.Instance.GetRoomIDs();
            TxtRoomID.Text = selected.roomId;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            RoomMerging rm = new RoomMerging();
            rm.RoomOne = selected.roomId;
            string dateStart = RStart.Text;
            string dateStartTime = dateStart + " " + TxtStartTime.Text;
            rm.MergeStart = DateTime.Parse(dateStartTime);
            string dateEnd = REnd.Text;
            string dateEndTime = dateEnd + " " + TxtEndTime.Text;
            rm.MergeEnd = DateTime.Parse(dateEndTime);
            rm.RoomTwo = TxtMergeRoom.Text;
            rm.RoomType = ManagerConversions.StringToRoomType(CbType.Text);
            rm.MergeID = Guid.NewGuid().ToString("N");

            roomMergingController.Create(rm);
            roomMergingController.MergeRooms(rm);

            this.Close(); 
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
