using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        private Equipment equipment;
        private RoomEquipment re;
        private List<RoomEquipment> reList;
        private List<Equipment> eqList;
        private ObservableCollection<Equipment> eqs;
        public AddEquipment(ObservableCollection<Equipment> listEq)
        {
            InitializeComponent();
            eqs = listEq;
            eqList = EquipmentRepository.Instance.GetAllToList();
            reList = RoomEquipmentRepository.Instance.GetAllToList();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            equipment = new Equipment();

            equipment.name = TxtName.Text;
            equipment.id = Guid.NewGuid().ToString("N");
            equipment.type = ManagerConversions.StringToEquipmentType(CbEqType.Text);
            equipment.quantity = Int32.Parse(TxtQuantity.Text);

            re = new RoomEquipment();
            bool createRe = true;
            foreach (var re in reList)
            {
                if (re.EquipmentName == equipment.name && re.RoomID == ManagerConversions.RoomTypesToString(RoomTypes.warehouse))
                {
                    re.Quantity += equipment.quantity;
                    RoomEquipmentRepository.Instance.Update(re);
                    createRe = false;
                    break;
                }
            }
            if (createRe)
            {
                re.EquipmentName = equipment.name;
                re.RoomID = ManagerConversions.RoomTypesToString(RoomTypes.warehouse);
                re.Quantity = equipment.quantity;
                RoomEquipmentRepository.Instance.Create(re);
            }

            foreach (var eq in eqList)
            {
                if (eq.name == equipment.name)
                {
                    eq.quantity += equipment.quantity;
                    EquipmentRepository.Instance.Update(eq);
                    this.Close();
                    return;
                }
            }
            EquipmentRepository.Instance.Create(equipment);
            eqs.Add(equipment);
            this.Close();
            return;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
