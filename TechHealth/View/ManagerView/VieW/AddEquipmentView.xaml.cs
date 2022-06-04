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

            equipment.name = TxtName.Text;
            equipment.id = Guid.NewGuid().ToString("N");
            equipment.type = ManagerConversions.StringToEquipmentType(CbEqType.Text);
            equipment.quantity = Int32.Parse(TxtQuantity.Text);
            re = new RoomEquipment();

            //bool createRe = true;
            //foreach (var re in reList)
            //{
            //    if (re.EquipmentName == equipment.name && re.RoomID == ManagerConversions.RoomTypesToString(RoomTypes.warehouse))
            //    {
            //        re.Quantity += equipment.quantity;
            //        RoomEquipmentRepository.Instance.Update(re);
            //        createRe = false;
            //        break;
            //    }
            //}
            bool createRe = roomEquipmentController.UpdateWarehouseRoomEquipment(reList, equipment);

            if (createRe)
            {
                roomEquipmentController.CreateWarehouseRoomEquipment(re, equipment);
            }

            //bool createEq = true;

            //foreach (var eq in eqList)
            //{
            //    if (eq.name == equipment.name)
            //    {
            //        eq.quantity += equipment.quantity;
            //        EquipmentRepository.Instance.Update(eq);
            //        //this.Close();
            //        //return;
            //        createEq = false;
            //        MainViewModel.Instance().CurrentView = EquipmentVm;
            //    }
            //}
            bool createEq = equipmentController.UpdateEquipmentQuantityIfItExists(eqList, equipment);

            if (createEq)
            {
                equipmentController.Create(equipment);
            }
            //eqs.Add(equipment);
            //this.Close();
            //return;
            MainViewModel.Instance().CurrentView = EquipmentVm;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            //this.Close();
            var EquipmentVm = new EquipmentViewModel();
            MainViewModel.Instance().CurrentView = EquipmentVm;
        }
    }
}
