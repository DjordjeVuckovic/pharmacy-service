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
    public partial class VacationRequestsView : Window
    {
        private ObservableCollection<DoctorVacationRequest> list = new ObservableCollection<DoctorVacationRequest>();
        private DoctorVacationRequestController doctorVacationRequestController = new DoctorVacationRequestController();
        public VacationRequestsView()
        {
            InitializeComponent();
            GenerateRequests();
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void GenerateRequests()
        {
            list.Clear();
            foreach (var r in doctorVacationRequestController.GetAll())
            {
                if (r.VacationStatus.Equals(VacationStatus.Waiting))
                {
                    list.Add(r);
                }
            }
            vacationRequestList.ItemsSource = list;
        }
        private void Button_Meetings(object sender, RoutedEventArgs e)
        {
            new MeetingsPickDate().Show();
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
            Close();
        }
        private void Button_Click_Approve(object sender, RoutedEventArgs e)
        {
            if (vacationRequestList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select a request.");
                return;
            }
            DoctorVacationRequest dVR = (DoctorVacationRequest)vacationRequestList.SelectedItems[0];
            doctorVacationRequestController.ApproveOrRejectVacation(dVR, VacationStatus.Approved);
            new NotificationReason(dVR).Show();
            Close();
        }
        private void Button_Click_Reject(object sender, RoutedEventArgs e)
        {
            if (vacationRequestList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select a request.");
                return;
            }
            DoctorVacationRequest dVR = (DoctorVacationRequest)vacationRequestList.SelectedItems[0];
            doctorVacationRequestController.ApproveOrRejectVacation(dVR, VacationStatus.Rejected);
            new NotificationReason(dVR).Show();
            Close();
        }
    }
}
