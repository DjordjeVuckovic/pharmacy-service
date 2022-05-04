using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.PatientView.View
{
    /// <summary>
    /// Interaction logic for SuggestedAppointmentsView.xaml
    /// </summary>
    public partial class SuggestedAppointmentsView : Page
    {
        private static ObservableCollection<Appointment> termini;
        private Patient patient;
        private string username;
        public SuggestedAppointmentsView()
        {
            InitializeComponent();
            DataContext = this;
            patient = PatientRepository.Instance.GetPatientByUser(username);
        }
        public static ObservableCollection<Appointment> Termini { get; set; }

        public void addTermini(List<Appointment> terminiPreporuka)
        {
            termini = new ObservableCollection<Appointment>(terminiPreporuka);
        }


        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            /*AddAppointment add = AddAppointment.getInstance();
            add.Zakazivanje1.Children.Clear();
            add.Zakazivanje1.Children.Add(new SuggestAppointment(patient));
            Back()*/
        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            AppointmentController appointmentController = new AppointmentController();
            appointmentController.Create(termini[PreporuceniTerminiTabela.SelectedIndex]);
            termini.Remove(termini[PreporuceniTerminiTabela.SelectedIndex]);
            AppointmentNotification notif = new AppointmentNotification();
            notif.TekstObavjestenja.Text = "Appointment succesfully scheduled";
            notif.ShowDialog();
        }
    }
}
