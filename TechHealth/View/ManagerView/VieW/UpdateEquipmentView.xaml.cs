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
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for UpdateEquipmentView.xaml
    /// </summary>
    public partial class UpdateEquipmentView : UserControl
    {
        private Equipment selected;
        private List<RoomEquipment> reList;
        private RoomEquipmentController roomEquipmentController = new RoomEquipmentController();
        private EquipmentController equipmentController = new EquipmentController();
        public UpdateEquipmentView()
        {
            var eq = UpdateEquipmentViewModel.Instance().getSelectedEquipment();
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
            try
            {
                selected.Quantity = Int32.Parse(TxtQuantity.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter a valid number for quantity!");
                return;
            }

            equipmentController.Update(selected);
            roomEquipmentController.UpdateRoomEqByEqName(reList, selected.Name);

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
