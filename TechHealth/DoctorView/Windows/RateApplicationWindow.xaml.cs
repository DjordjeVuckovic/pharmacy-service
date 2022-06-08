using System.Windows;

namespace TechHealth.DoctorView.Windows
{
    public partial class RateApplicationWindow : Window
    {
        public RateApplicationWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your are successfully rated our app.Thank you for feedback!");
            Close();
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}