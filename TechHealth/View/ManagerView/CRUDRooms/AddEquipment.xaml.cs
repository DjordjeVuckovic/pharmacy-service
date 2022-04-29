using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TechHealth.View.ManagerView.VieW;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        private Equipment equipment;
        //private List<String> roomIDs;
        private List<String> eqNames;
        private List<Room> rooms;
        private List<Equipment> eqList;
        private RoomController roomController = new RoomController();
        private ObservableCollection<Equipment> eqs;
        public AddEquipment(ObservableCollection<Equipment> listEq)
        {
            InitializeComponent();
            eqs = listEq;
            eqList = EquipmentRepository.Instance.DictionaryValuesToList();
            rooms = RoomRepository.Instance.DictionaryValuesToList();
            //roomIDs = RoomRepository.Instance.GetRoomIDs();
            eqNames = EquipmentRepository.Instance.GetEqNames();
            //CbRoomID.ItemsSource = roomIDs;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            equipment = new Equipment();

            equipment.name = TxtName.Text;
            equipment.id = Guid.NewGuid().ToString("N");
            equipment.type = ManagerConversions.StringToEquipmentType(CbEqType.Text);
            equipment.quantity = Int32.Parse(TxtQuantity.Text);
            equipment.roomID = ManagerConversions.RoomTypesToString(RoomTypes.warehouse);

            foreach (var room in rooms)     
            {
                if (room.roomTypes == RoomTypes.warehouse)
                {
                    List<Equipment> eqListWarehouse = EquipmentRepository.Instance.GetEqListByRoomID(equipment.roomID);
                    foreach (var eq in eqListWarehouse)
                    {
                        if (eq.name == equipment.name)
                        {
                            eq.quantity += equipment.quantity;
                            EquipmentRepository.Instance.Update(eq);

                            int index = EquipmentRepository.Instance.GetEqIndex(eq.name, eqListWarehouse);
                            eqListWarehouse[index].quantity = eq.quantity;
                            room.equipment = eqListWarehouse;
                            roomController.Update(room);
                            this.Close();
                            return;
                        }
                    }
                    EquipmentRepository.Instance.Create(equipment);
                    eqs.Add(equipment);
                    room.equipment.Add(equipment);
                    roomController.Update(room);
                    this.Close();
                    return;

                }
                else
                {
                    continue;
                }
            }
            MessageBox.Show("Warehouse doesn't exist!");
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
