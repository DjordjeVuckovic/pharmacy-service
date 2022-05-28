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
using TechHealth.Service;
using System.Collections.ObjectModel;

namespace TechHealth.View.SecretaryView
{
    public partial class EquipmentRequestsView : Window
    {
        private ObservableCollection<EquipmentRequest> requests = new ObservableCollection<EquipmentRequest>();
        private RoomEquipmentController roomEquipmentController = new RoomEquipmentController();
        public EquipmentRequestsView()
        {
            InitializeComponent();
            foreach (var er in EquipmentRequestRepository.Instance.GetAll().Values)
            {
                requests.Add(er);
            }
            requestList.ItemsSource = requests;
        }
        private void Button_Guests(object sender, RoutedEventArgs e)
        {
            new GuestsView().Show();
            Close();
        }
        private void Button_Accounts(object sender, RoutedEventArgs e)
        {
            new AccountsView().Show();
            Close();
        }
        private void Button_Appointments(object sender, RoutedEventArgs e)
        {
            new AppointmentsPickDate().Show();
            Close();
        }
        private void Button_Equipment(object sender, RoutedEventArgs e)
        {
            new EquipmentRequestsView().Show();
            Close();
        }
        private void Button_EmergencyExamination(object sender, RoutedEventArgs e)
        {
            new EmergencyExamination().Show();
            Close();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Store(object sender, RoutedEventArgs e)
        {
            EquipmentRequest equipmentRequest = CheckSelect();
            if (equipmentRequest == null){ return; }
            roomEquipmentController.UpdateQuantityWithRequest(equipmentRequest);
            EquipmentRequestRepository.Instance.Delete(equipmentRequest.RequestId);
            Update();
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Hide();
            new AddEquipmentRequest().Show();
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            EquipmentRequest equipmentRequest = CheckSelect();
            if (equipmentRequest == null) { return; }
            EquipmentRequestRepository.Instance.Delete(equipmentRequest.RequestId);
            Update();
        }
        public void Update()
        {
            requests.Clear();
            foreach (var er in EquipmentRequestRepository.Instance.GetAll().Values)
            {
                requests.Add(er);
            }
        }
        private EquipmentRequest CheckSelect()
        {
            if (requestList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select a request.");
                return null;
            }
            EquipmentRequest equipmentRequest = (EquipmentRequest)requestList.SelectedItems[0];
            return equipmentRequest;
        }
    }
}
