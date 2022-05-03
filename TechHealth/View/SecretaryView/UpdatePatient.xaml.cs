using System;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Model;
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
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            var address = new Address();

            address.Street = accountStreet.Text;
            address.StreetNumber = accountStreetNumber.Text;
            address.City = accountCity.Text;
            address.Country = accountCountry.Text;
            address.Postcode = Int32.Parse(accountPostcode.Text);

            patientController.Update(accountName.Text, accountSurname.Text, address, null, accountJmbg.Text, Int32.Parse(accountLbo.Text), false, accountUsername.Text, accountPassword.Text, accountEmail.Text, false, false, accountPhone.Text);

            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
