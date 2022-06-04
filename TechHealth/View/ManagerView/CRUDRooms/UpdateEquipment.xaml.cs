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

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for UpdateEquipment.xaml
    /// </summary>
    public partial class UpdateEquipment : Window
    {
        private Equipment selected;
        private List<RoomEquipment> reList;
        private RoomEquipmentController roomEquipmentController = new RoomEquipmentController();
        public UpdateEquipment(Equipment eq)
        {
            selected = EquipmentRepository.Instance.GetById(eq.Id);
            reList = roomEquipmentController.GetRoomEqListByEqName(selected.Name);
            InitializeComponent();

            TxtName.Text = selected.Name;
            CbEqType.Text = ManagerConversions.EquipmentTypeToString(selected.Type);
            TxtQuantity.Text = selected.Quantity.ToString();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            selected.Name = TxtName.Text;
            selected.Type = ManagerConversions.StringToEquipmentType(CbEqType.Text);
            selected.Quantity = Int32.Parse(TxtQuantity.Text);

            EquipmentRepository.Instance.Update(selected);
            roomEquipmentController.UpdateRoomEqByEqName(reList, selected.Name);
            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
