using System.Windows;
using System.Windows.Controls;
using TechHealth.DoctorView.Windows;

namespace TechHealth.DoctorView.View
{
    public partial class HospitalizationView : UserControl
    {
        public HospitalizationView()
        {
            InitializeComponent();
        }

        private void Extend(object sender, RoutedEventArgs e)
        {
            new ExtendStayWindow().ShowDialog();
        }

        private void Realse(object sender, RoutedEventArgs e)
        {
            new ReleasePatientWindow().ShowDialog();
        }
    }
}