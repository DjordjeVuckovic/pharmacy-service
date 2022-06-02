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
    /// Interaction logic for UpdateAccount.xaml
    /// </summary>
    public partial class UpdatePatient : Window
    {
        private PatientController patientController = new PatientController();
        public UpdatePatient(Patient patient)
        {
            Patient p = PatientRepository.Instance.GetById(patient.Jmbg);
            InitializeComponent();
            this.DataContext = this;

            accountName.Text = p.Name;
            accountSurname.Text = p.Surname;
            accountJmbg.Text = p.Jmbg;
            accountLbo.Text = p.Lbo.ToString();
            accountEmail.Text = p.Email;
            accountPhone.Text = p.Phone;
            accountUsername.Text = p.Username;
            accountPassword.Text = p.Password;
            if (p.Address != null)
            {
                accountStreet.Text = p.Address.Street;
                accountStreetNumber.Text = p.Address.StreetNumber;
                accountCity.Text = p.Address.City;
                accountCountry.Text = p.Address.Country;
                accountPostcode.Text = p.Address.Postcode.ToString();
            }
            else
            {
                accountStreet.Text = "";
                accountStreetNumber.Text = "";
                accountCity.Text = "";
                accountCountry.Text = "";
                accountPostcode.Text = "";
            }
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
            this.Close();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            var address = new Address();

            address.Street = accountStreet.Text;
            address.StreetNumber = accountStreetNumber.Text;
            address.City = accountCity.Text;
            address.Country = accountCountry.Text;
            address.Postcode = Int32.Parse(accountPostcode.Text);

            foreach (var patient in PatientRepository.Instance.GetAll().Values)
            {
                if (patient.Username.Equals(accountUsername.Text) && patient.Jmbg != accountJmbg.Text)
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }
            }

            patientController.Update(accountName.Text, accountSurname.Text, address, null, accountJmbg.Text, Int32.Parse(accountLbo.Text), false, accountUsername.Text, accountPassword.Text, accountEmail.Text, false, false, accountPhone.Text);

            this.Close();
            new AccountsView().Show();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            new AccountsView().Show();
        }
    }
}
