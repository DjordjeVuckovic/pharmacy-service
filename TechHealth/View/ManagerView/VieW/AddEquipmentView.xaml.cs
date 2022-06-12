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
    /// Interaction logic for AddEquipmentView.xaml
    /// </summary>
    public partial class AddEquipmentView : UserControl
    {
        private Equipment equipment;
        private RoomEquipment re;
        private List<RoomEquipment> reList;
        private List<Equipment> eqList;
        private EquipmentController equipmentController = new EquipmentController();
        private RoomEquipmentController roomEquipmentController = new RoomEquipmentController();
        //private ObservableCollection<Equipment> eqs;
        public AddEquipmentView(/*ObservableCollection<Equipment> listEq*/)
        {
            InitializeComponent();
            //eqs = listEq;
            eqList = equipmentController.GetAllToList();
            reList = roomEquipmentController.GetAllToList();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            equipment = new Equipment();
            var EquipmentVm = new EquipmentViewModel();

            equipment.Name = TxtName.Text;
            equipment.Id = Guid.NewGuid().ToString("N");
            equipment.Type = ManagerConversions.StringToEquipmentType(CbEqType.Text);
            try
            {
                equipment.Quantity = Int32.Parse(TxtQuantity.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter a valid number for quantity!");
                return;
            }
            re = new RoomEquipment();


            if (TxtName.Text == "" || CbEqType.Text == "" || TxtQuantity.Text == "")
            {
                MessageBox.Show("All fields have to be filled in order to proceed!");
                return;
            }

            foreach (var eq in equipmentController.GetAllToList())
            {
                if (equipment.Name == eq.Name)
                {
                    if (equipment.Type != eq.Type)
                    MessageBox.Show("Invalid type!");
                    return;
                }
            }

            bool createRe = roomEquipmentController.UpdateWarehouseRoomEquipment(reList, equipment);

            if (createRe)
            {
                roomEquipmentController.CreateWarehouseRoomEquipment(re, equipment);
            }

            bool createEq = equipmentController.UpdateEquipmentQuantityIfItExists(eqList, equipment);

            if (createEq)
            {
                equipmentController.Create(equipment);
            }
 
            MainViewModel.Instance().CurrentView = EquipmentVm;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            var EquipmentVm = new EquipmentViewModel();
            MainViewModel.Instance().CurrentView = EquipmentVm;
        }
    }
}
