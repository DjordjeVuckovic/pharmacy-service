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
