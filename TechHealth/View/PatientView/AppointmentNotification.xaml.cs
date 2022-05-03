using System.Windows;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for AppointmentNotification.xaml
    /// </summary>
    public partial class AppointmentNotification : Window
    {
        public AppointmentNotification()
        {
            InitializeComponent();
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
