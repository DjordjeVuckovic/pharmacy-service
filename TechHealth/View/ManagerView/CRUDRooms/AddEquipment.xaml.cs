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

            equipment.Name = TxtName.Text;
            equipment.Id = Guid.NewGuid().ToString("N");
            equipment.Type = ManagerConversions.StringToEquipmentType(CbEqType.Text);
            equipment.Quantity = Int32.Parse(TxtQuantity.Text);
            re = new RoomEquipment();
            
            bool createRe = true;
            foreach (var re in reList)
            {
                if (re.EquipmentName == equipment.Name && re.RoomID == ManagerConversions.RoomTypesToString(RoomTypes.warehouse))
                {
                    re.Quantity += equipment.Quantity;
                    RoomEquipmentRepository.Instance.Update(re);
                    createRe = false;
                    break;
                }
            }
            if (createRe)
            {
                re.EquipmentName = equipment.Name;
                re.RoomID = ManagerConversions.RoomTypesToString(RoomTypes.warehouse);
                re.Quantity = equipment.Quantity;
                RoomEquipmentRepository.Instance.Create(re);
            }

            foreach (var eq in eqList)
            {
                if (eq.Name == equipment.Name)
                {
                    eq.Quantity += equipment.Quantity;
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
