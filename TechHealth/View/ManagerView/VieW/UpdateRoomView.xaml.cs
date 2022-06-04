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
    /// Interaction logic for UpdateRoomView.xaml
    /// </summary>
    public partial class UpdateRoomView : UserControl
    {
        private Room selected;
        private RoomController roomController = new RoomController();
        public UpdateRoomView()
        {
            var room = UpdateRoomViewModel.Instance().getSelectedRoom();
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

            roomController.Update(selected);

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
