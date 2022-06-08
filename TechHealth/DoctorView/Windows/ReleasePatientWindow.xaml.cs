using System.Windows;

namespace TechHealth.DoctorView.Windows
{
    public partial class ReleasePatientWindow : Window
    {
        public ReleasePatientWindow()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your are successfully release patient: Dusan Vukovic.");
            Close();
        }
    }
}