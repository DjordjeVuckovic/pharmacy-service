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
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for AddRenovationView.xaml
    /// </summary>
    public partial class AddRenovationView : UserControl
    {
        private List<String> rooms;
        private Room selected;
        private RoomRenovation rr;
        private EquipmentReallocationController equipmentReallocationController = new EquipmentReallocationController();
        private RoomRenovationController roomRenovationContoller = new RoomRenovationController();
        private RoomController roomController = new RoomController();
        public RelayCommand CancelRenovationCommand { get; set; }

        //public AddRenovationView() {}
        public AddRenovationView(/*Room rm*/)
        {
            InitializeComponent();
            DataContext = this;
            Room rm = AddRenovationViewModel.Instance().getSelectedRoom();
            selected = rm;
            rooms = roomController.GetRoomIDs();
            TxtRoomID.Text = selected.roomId;
            CancelRenovationCommand = new RelayCommand(param => ExeceuteCancel(), param => CanExecuteCancel());

            rr = roomRenovationContoller.GetRrByRoomID(selected.roomId);
            RStart.SelectedDate = rr.RenovationStart;
            REnd.SelectedDate = rr.RenovationEnd;
        }

        private bool CanExecuteCancel()
        {
            return !roomRenovationContoller.ExistsInRenovations(selected.roomId);
        }

        private void ExeceuteCancel()
        {
            roomRenovationContoller.Delete(rr.RenovationID);
            var RoomVm = new RoomViewModel();
            MainViewModel.Instance().CurrentView = RoomVm;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            RoomRenovation r = new RoomRenovation();
            r.RoomID = selected.roomId;
            //string date = DpDateTime.Text;
            //string dateTime = date + " " + TxtTime.Text;
            //dto.ReallocationTime = DateTime.Parse(dateTime);
            string dateStart = RStart.Text;
            string dateStartTime = dateStart + " " + TxtStartTime.Text;
            r.RenovationStart = DateTime.Parse(dateStartTime);
            //r.RenovationStart = (DateTime)RStart.SelectedDate;
            string dateEnd = REnd.Text;
            string dateEndTime = dateEnd + " " + TxtEndTime.Text;
            r.RenovationEnd = DateTime.Parse(dateEndTime);
            //r.RenovationEnd = (DateTime)REnd.SelectedDate;
            r.RenovationID = Guid.NewGuid().ToString("N");

            if (roomRenovationContoller.ExistsInRenovations(selected.roomId))     //da li je vec zakazano renoviranje te sobe
            {
                if (AppointmentRepository.Instance.CanSetRenovation(r.RenovationStart, r.RenovationEnd, r.RoomID))  //da li ima app zakazan u tom periodu
                {
                    if (!equipmentReallocationController.IsReallocationHappening(r.RenovationStart, r.RenovationEnd, r.RoomID))
                    {
                        roomRenovationContoller.Create(r);
                        var RoomVm = new RoomViewModel();
                        MainViewModel.Instance().CurrentView = RoomVm;
                    }
                    else
                    {
                        MessageBox.Show("Reallocation is happening in that period!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("There is an appointment scheduled in that period!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("This room already has scheduled renovation!");
                return;
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            var RoomVm = new RoomViewModel();
            MainViewModel.Instance().CurrentView = RoomVm;
        }
    }
}
