using System.Windows;
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    public partial class UpdateForm : Window
    {
        private Room selected;
        private RoomController roomController = new RoomController();
        public UpdateForm(Room room)
        {
            selected = RoomRepository.Instance.GetById(room.roomId);
            InitializeComponent();

            //this.DataContext = this;

            TxtRoomId.Text = selected.roomId;
            CbFloor.Text = ManagerConversions.FloorToString(selected.floor);
            CbType.Text = ManagerConversions.RoomTypesToString(selected.roomTypes);
            CbAvailability.Text = ManagerConversions.AvailabilityToString(selected.availability);

        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            selected.floor = ManagerConversions.StringToFloor(CbFloor.Text);
            selected.roomTypes = ManagerConversions.StringToRoomType(CbType.Text);
            selected.availability = ManagerConversions.StringToAvailability(CbAvailability.Text);

            //roomController.Update(selected.roomId, selected.floor, selected.availability,selected.roomTypes, selected.equipment);
            roomController.Update(selected);
            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
