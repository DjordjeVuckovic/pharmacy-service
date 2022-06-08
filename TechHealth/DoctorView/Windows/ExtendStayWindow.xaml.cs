using System.Windows;

namespace TechHealth.DoctorView.Windows
{
    public partial class ExtendStayWindow : Window
    {
        public ExtendStayWindow()
        {
            InitializeComponent();
        }

        private void ButtonFinish(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your are successfully extended stay for patient Dusan Vukovic.");
            Close();
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}