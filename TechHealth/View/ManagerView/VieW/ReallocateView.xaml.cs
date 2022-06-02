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
using TechHealth.DTO;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for ReallocateView.xaml
    /// </summary>
    public partial class ReallocateView : UserControl
    {
        //private List<Equipment> eqList;
        private List<String> rooms;
        private List<String> dstRooms;
        private Equipment selected;
        private List<Room> eqs;
        private EquipmentReallocationController reallocationController = new EquipmentReallocationController();
        private RoomEquipmentController roomEquipmentController = new RoomEquipmentController();
        private EquipmentController equipmentController = new EquipmentController();
        private RoomController roomController = new RoomController();
        private RoomRenovationController roomRenovationController = new RoomRenovationController();
        public ReallocateView()
        {
            InitializeComponent();
            DataContext = this;
            var eq = ReallocateViewModel.Instance().getSelectedEquipment();
            selected = EquipmentRepository.Instance.GetById(eq.id);
            rooms = roomController.GetRoomNames();
            //eqList = EquipmentRepository.Instance.GetAllToList();
            //eqs = RoomRepository.Instance.GetRoomsByEq(selected.name);
            //dstRooms = RoomRepository.Instance.GetRoomNames(eqs);
            CbSourceRoom.ItemsSource = rooms;
            CbDestinationRoom.ItemsSource = rooms;
            TxtEqId.Text = selected.name;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            EquipmentReallocationDTO dto = new EquipmentReallocationDTO();
            dto.EquipmentName = TxtEqId.Text;
            dto.SourceRoomID = CbSourceRoom.Text;
            dto.DestinationRoomID = CbDestinationRoom.Text;
            dto.AmountMoving = Int32.Parse(TxtAmount.Text);
            string date = DpDateTime.Text;
            string dateTime = date + " " + TxtTime.Text;
            dto.ReallocationTime = DateTime.Parse(dateTime);
            //dto.ReallocationTime = DpDateTime.SelectedDate;
            dto.ReallocationID = Guid.NewGuid().ToString("N");

            RoomEquipment reDst = new RoomEquipment();
            RoomEquipment reSrc = new RoomEquipment();
            reDst = roomEquipmentController.GetReByKey(dto.EquipmentName, dto.DestinationRoomID);
            reSrc = roomEquipmentController.GetReByKey(dto.EquipmentName, dto.SourceRoomID);

            if (!(reSrc.Quantity >= dto.AmountMoving))
            {
                MessageBox.Show("Can't trasnfer that much!");
                return;
            }
            if (dto.SourceRoomID != dto.DestinationRoomID)
            {
                if (AppointmentRepository.Instance.CanDoReallocation(dto.ReallocationTime, dto.SourceRoomID, dto.DestinationRoomID))
                {
                    if (roomRenovationController.IsValidDate(dto.ReallocationTime, dto.SourceRoomID, dto.DestinationRoomID))
                    {
                        if (DateTime.Compare(DateTime.Now, dto.ReallocationTime) == 0)
                        {
                            reallocationController.SubmitReallocation(dto);
                        }
                        else
                        {
                            reallocationController.Create(dto);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid date!");
                    }
                }
                else
                {
                    MessageBox.Show("There is an appointment scheduled on that date!");
                }
            }
            else
            {
                MessageBox.Show("Invalid rooms for transfer selected!");
                return;
            }
            var EqVm = new EquipmentViewModel();
            MainViewModel.Instance().CurrentView = EqVm;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            var EqVm = new EquipmentViewModel();
            MainViewModel.Instance().CurrentView = EqVm;
        }
    }
}
