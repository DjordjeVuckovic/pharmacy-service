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
using TechHealth.Repository;
using TechHealth.Model;

namespace TechHealth.View.SecretaryView
{
    public partial class AddEquipmentRequest : Window
    {
        public AddEquipmentRequest()
        {
            InitializeComponent();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            EquipmentRequest er = new EquipmentRequest(Guid.NewGuid().ToString("N"), equipmentName.Text, Int32.Parse(quantity.Text));
            EquipmentRequestRepository.Instance.Create(er);
            new AddEquipmentRequest().Show();
            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            new EquipmentRequestsView().Show();
            this.Close();
        }
    }
}
