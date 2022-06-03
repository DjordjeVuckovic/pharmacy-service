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
    public partial class MeetingsView : Window
    {
        private ObservableCollection<Meeting> meetings = new ObservableCollection<Meeting>();
        private DateTime d;
        public MeetingsView(DateTime date)
        {
            InitializeComponent();
            d = date;
            pickedDate.Content = "Meetings " + date.ToString("dd.MM.yyyy.");
            foreach (var m in MeetingRepository.Instance.GetAll().Values)
            {
                meetings.Add(m);
            }
            meetingList.ItemsSource = meetings;
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
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
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            new AddMeeting(d).Show();
            Close();
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
        }
        private void Update()
        {
        }
    }
}
