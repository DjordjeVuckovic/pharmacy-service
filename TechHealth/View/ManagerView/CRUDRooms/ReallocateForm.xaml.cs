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
        //private List<Equipment> eqList;
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
            dto.ReallocationTime = DpDateTime.SelectedDate;
            dto.ReallocationID = Guid.NewGuid().ToString("N");
            //sve ovo bi trebalo da se spakuje u jednu funkciju koja bi isla u kontroller pa u service gde bi se ova logika izvrsavala
            //if (dto.SourceRoomID != dto.DestinationRoomID)
            //{
            //    if (AppointmentRepository.Instance.CanDoReallocation(dto.ReallocationTime, dto.SourceRoomID, dto.DestinationRoomID))
            //    {     //dodato poslednje
            //        if (RoomRenovationRepository.Instance.IsValidDate(dto.ReallocationTime, dto.SourceRoomID, dto.DestinationRoomID))
            //        {    //dodato
            //             //reallocationController.Create(dto);

            //            //update roomEquipment fajla
            //            RoomEquipment reDst = new RoomEquipment();
            //            RoomEquipment reSrc = new RoomEquipment();
            //            reDst = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.DestinationRoomID);
            //            reSrc = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.SourceRoomID);
            //            if (RoomEquipmentRepository.Instance.ReEqExists(dto.EquipmentName, dto.DestinationRoomID))
            //            {
            //                if (reSrc.Quantity >= dto.AmountMoving)
            //                {
            //                    reallocationController.Create(dto); //dodato
            //                                                        //reDst = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.DestinationRoomID);
            //                    reDst.Quantity += dto.AmountMoving;
            //                    RoomEquipmentRepository.Instance.Update(reDst);

            //                    //reSrc = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.SourceRoomID);

            //                    reSrc.Quantity -= dto.AmountMoving;
            //                    RoomEquipmentRepository.Instance.Update(reSrc);
            //                    this.Close();
            //                    return;
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Can't transfer that much!");
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                if (reSrc.Quantity >= dto.AmountMoving)
            //                {
            //                    reallocationController.Create(dto); //dodato
            //                    reDst.EquipmentName = dto.EquipmentName;
            //                    reDst.RoomID = dto.DestinationRoomID;
            //                    reDst.Quantity = dto.AmountMoving;
            //                    RoomEquipmentRepository.Instance.Create(reDst);

            //                    reSrc = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.SourceRoomID);

            //                    reSrc.EquipmentName = dto.EquipmentName;
            //                    reSrc.RoomID = dto.SourceRoomID;
            //                    reSrc.Quantity -= dto.AmountMoving;
            //                    RoomEquipmentRepository.Instance.Update(reSrc);
            //                    this.Close();
            //                    return;
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Can't transfer that much!");
            //                }
            //            }
            //        } //dodato
            //        else               //dodato
            //        {                                              //dodato
            //            MessageBox.Show("Invalid date!");       //dodato
            //        }                   //dodato
            //    }
            //    else//dodato poslednje
            //    {//dodato poslednje
            //        MessageBox.Show("There is an appointment scheduled on that date!");//dodato poslednje
            //    }//dodato poslednje
            //}
            //else
            //{
            //    MessageBox.Show("Invalid rooms for transfer selected!");
            //    return;
            //}
            reallocationController.SubmitReallocation(dto);
            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
