using System.Windows;
using System.Windows.Threading;
using TechHealth.View.DoctorView.CRUDAppointments;

namespace TechHealth.View.DoctorView
{
    public partial class DoctorMainWindow : Window
    {
        public DoctorMainWindow()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Examination_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateSurgery().ShowDialog();
        }

        private void UpdateSurgery_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateSurgery().ShowDialog();
        }

        private void Surgery_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateSurgery().ShowDialog();
        }
    }
}