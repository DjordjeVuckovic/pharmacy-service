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
using TechHealth.Controller;
using TechHealth.Repository;

namespace TechHealth.View.SecretaryView
{
    public partial class AddGuest : Window
    {
        private PatientController patientController = new PatientController();
        private bool isEmergency;
        public AddGuest(bool emergency)
        {
            InitializeComponent();
            isEmergency = emergency;
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
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            int guestId = 1;
            foreach (var p in PatientRepository.Instance.GetAll().Values)
            {
                if (p.Guest)
                {
                    string str = p.Jmbg.Remove(0, 5);
                    if (guestId != Int32.Parse(str))
                    {
                        break;
                    }
                    else
                    {
                        guestId++;
                    }
                }
            }
            foreach (var patient in PatientRepository.Instance.GetAll().Values)
            {
                if (patient.Username.Equals(guestUsername.Text) && patient.Jmbg != ("guest" + guestId.ToString()))
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }
            }
            patientController.Create(guestUsername.Text, "", null, null, "guest" + guestId.ToString(), 0, false, guestUsername.Text, guestPassword.Text, "", false, true, "");
            guestId++;
            Close();
            if (isEmergency)
            {
                new EmergencyExamination().Show();
            }
            else
            {
                new GuestsView().Show();
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
            if (isEmergency)
            {
                new EmergencyExamination().Show();
            }
            else
            {
                new GuestsView().Show();
            }
        }
    }
}
