using System.Windows;
using TechHealth.Controller;
using TechHealth.Model;
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

            this.Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
