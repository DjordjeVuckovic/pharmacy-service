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
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Controller;
using System.Collections.ObjectModel;

namespace TechHealth.View.SecretaryView
{
    public partial class EquipmentRequestsView : Window
    {
        private ObservableCollection<EquipmentRequest> requests = new ObservableCollection<EquipmentRequest>();
        public EquipmentRequestsView()
        {
            InitializeComponent();
            foreach (var er in EquipmentRequestRepository.Instance.GetAll().Values)
            {
                requests.Add(er);
            }
            requestList.ItemsSource = requests;
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
        }
        public void Update()
        {
            requests.Clear();
            foreach (var er in EquipmentRequestRepository.Instance.GetAll().Values)
            {
                requests.Add(er);
            }
        }
    }
}
