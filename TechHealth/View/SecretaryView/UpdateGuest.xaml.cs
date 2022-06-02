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
    /// <summary>
    /// Interaction logic for UpdateGuest.xaml
    /// </summary>
    public partial class UpdateGuest : Window
    {
        private PatientController patientController = new PatientController();
        private string guestId;
        public UpdateGuest(Patient patient)
        {
            Patient p = PatientRepository.Instance.GetById(patient.Jmbg);
            InitializeComponent();
            this.DataContext = this;

            guestUsername.Text = p.Username;
            guestPassword.Text = p.Password;
            guestId = p.Jmbg;
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
            this.Close();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            patientController.Update("", "", null, null, guestId, 0, false, guestUsername.Text, guestPassword.Text, "", false, true, "");

            Close();
            new GuestsView().Show();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
            new GuestsView().Show();
        }
    }
}
