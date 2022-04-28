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
using TechHealth.DTO;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for ReallocateForm.xaml
    /// </summary>
    public partial class ReallocateForm : Window
    {
        private List<Equipment> eqList;
        private List<String> rooms;
        private List<String> dstRooms;
        private Equipment selected;
        private List<Room> eqs;
        private EquipmentReallocationController reallocationController = new EquipmentReallocationController();
        private EquipmentController equipmentController = new EquipmentController();
        private RoomController roomController = new RoomController();
        public ReallocateForm(Equipment eq)
        {
            InitializeComponent();
            DataContext = this;
            selected = EquipmentRepository.Instance.GetById(eq.id);
            rooms = RoomRepository.Instance.GetRoomNames();
            eqList = EquipmentRepository.Instance.DictionaryValuesToList();
            eqs = RoomRepository.Instance.GetRoomsByEq(selected.name);
            dstRooms = RoomRepository.Instance.GetRoomNames(eqs);
            CbSourceRoom.ItemsSource = dstRooms;
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
            dto.ReallocationTime = DpDateTime.SelectedDate;
            dto.ReallocationID = Guid.NewGuid().ToString("N");

            reallocationController.Create(dto);

            //update room fajla

            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
