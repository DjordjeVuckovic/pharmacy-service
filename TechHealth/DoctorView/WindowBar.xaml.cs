using System.Windows;
using System.Windows.Controls;

namespace TechHealth.DoctorView
{
    public partial class WindowBar : Page
    {
        public WindowBar()
        {
            InitializeComponent();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            for (int intCounter = Application.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                Application.Current.Windows[intCounter]?.Close();
        }
    }
}