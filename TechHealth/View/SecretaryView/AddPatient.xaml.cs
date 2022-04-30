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

namespace TechHealth.View.SecretaryView
{
    public partial class AddPatient : Window
    {
        private PatientController patientController = new PatientController();
        public AddPatient()
        {
            InitializeComponent();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            var address = new Address();

            address.Street = accountStreet.Text;
            address.StreetNumber = accountStreetNumber.Text;
            address.City = accountCity.Text;
            address.Country = accountCountry.Text;
            address.Postcode = Int32.Parse(accountPostcode.Text);

            patientController.Create(accountName.Text, accountSurname.Text, address, null, accountJmbg.Text, Int32.Parse(accountLbo.Text), false, accountUsername.Text, accountPassword.Text, accountEmail.Text, false, false, accountPhone.Text);

            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accountStreet_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
