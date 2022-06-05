using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            CloseApp();
        }

        private static void CloseApp()
        {
            for (int intCounter = Application.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                Application.Current.Windows[intCounter]?.Close();
        }

        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System && e.SystemKey == Key.F4)
            {
                CloseApp();
            }
        }
    }
}