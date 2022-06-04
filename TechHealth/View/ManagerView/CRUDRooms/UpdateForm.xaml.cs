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
using TechHealth.Conversions;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    public partial class UpdateForm : Window
    {
        private Room selected;
        private RoomController roomController = new RoomController();
        public UpdateForm(Room room)
        {
            selected = RoomRepository.Instance.GetById(room.RoomId);
            InitializeComponent();

            //this.DataContext = this;

            TxtRoomId.Text = selected.RoomId;
            CbFloor.Text = ManagerConversions.FloorToString(selected.Floor);
            CbType.Text = ManagerConversions.RoomTypesToString(selected.RoomTypes);
            CbAvailability.Text = ManagerConversions.AvailabilityToString(selected.Availability);
            
        } 

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            selected.Floor = ManagerConversions.StringToFloor(CbFloor.Text);
            selected.RoomTypes = ManagerConversions.StringToRoomType(CbType.Text);
            selected.Availability = ManagerConversions.StringToAvailability(CbAvailability.Text);

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
