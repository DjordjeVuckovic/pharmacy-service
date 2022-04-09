using System.Windows;
using System.Windows.Threading;

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
    }
}