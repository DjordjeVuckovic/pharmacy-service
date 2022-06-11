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
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
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
        private void Button_Meetings(object sender, RoutedEventArgs e)
        {
            new MeetingsPickDate().Show();
            Close();
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void Button_Click_Report(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateFrom = DateTime.Parse(datePickerFrom.Text);
                DateTime dateTo = DateTime.Parse(datePickerTo.Text);
            }
            catch
            {
                MessageBox.Show("You didn't select a date.");
                return;
            }

            List<Appointment> list = new List<Appointment>();
            foreach (var a in AppointmentRepository.Instance.GetAllToList())
            {
                if (DateTime.Compare(a.Date, DateTime.Parse(datePickerFrom.Text)) >= 0)
                {
                    if (DateTime.Compare(a.Date, DateTime.Parse(datePickerTo.Text)) <= 0)
                    {
                        list.Add(a);
                    }
                }
            }
            foreach (var a in list)
            {
                
            }
        }
    }
}
