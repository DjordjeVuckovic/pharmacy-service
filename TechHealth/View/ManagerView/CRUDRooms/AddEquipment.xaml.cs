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
using TechHealth.View.ManagerView.VieW;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        private Equipment equipment;
        private List<String> roomIDs;
        private List<String> eqNames;
        private List<Room> rooms;
        private List<Equipment> eqList;
        private RoomController roomController = new RoomController();
        public AddEquipment()
        {
            InitializeComponent();
            eqList = EquipmentRepository.Instance.DictionaryValuesToList();
            rooms = RoomRepository.Instance.DictionaryValuesToList();
            roomIDs = RoomRepository.Instance.GetRoomIDs();
            eqNames = EquipmentRepository.Instance.GetEqNames();
            CbRoomID.ItemsSource = roomIDs;
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            equipment = new Equipment();

            equipment.name = TxtName.Text;
            equipment.id = Guid.NewGuid().ToString("N");
            equipment.type = ManagerConversions.StringToEquipmentType(CbEqType.Text);
            equipment.quantity = Int32.Parse(TxtQuantity.Text);
            equipment.roomID = CbRoomID.Text;

            //parametri treba da se proslede kontroleru pa zatim servisu i tamo treba da se premeste ove funkcije
            //treba popraviti da kad se doda isti tip opreme u drugu sobu, da se lepo azuriraju fajlovi s podacima i tabele
            foreach (var room in rooms)     //provera da li vec postoji oprema u istoj sobi, ako postoji, azurira se kolicina u tabeli opreme i sobi
            {
                foreach (var eq in eqList)
                {
                    if (eq.name == equipment.name && room.roomId == eq.roomID)
                    {
                        eq.quantity += equipment.quantity;
                        EquipmentRepository.Instance.Update(eq);

                        int index = EquipmentRepository.Instance.GetEqIndex(eq.name, room.equipment);
                        room.equipment[index] = eq;
                        roomController.Update(room);
                        this.Close();
                        return;
                    }
                }
            }

            foreach (var room in rooms)     //dodavanje kreirane opreme u odgovarajucu sobu
            {
                if (room.roomId == equipment.roomID)
                {
                    room.equipment.Add(equipment);
                    roomController.Update(room);
                }
            }

            EquipmentRepository.Instance.Create(equipment);
            EquipmentView eqView = new EquipmentView();
            eqView.Equipment.Add(equipment);
            this.Close();
 
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
