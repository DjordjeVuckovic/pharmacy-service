using System.Windows;
using System.Windows.Input;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.ViewModel;

namespace TechHealth.DoctorView
{
    public partial class DoctorWindow : Window
    {
        private readonly WindowBar bar = new WindowBar();

        public DoctorWindow(string doctorJmbg)
        {
            InitializeComponent();
            DataContext = MainViewModel.GetInstance(doctorJmbg);
            WindowBarFrame.Content = bar;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Signout();
        }

        private void Signout()
        {
            if (MessageBox.Show("Are you sure you want to log out ?",
                    "Log out", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new LoginWindow().Show();
                Close();
            }
        }

        private void OnDragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Signout();
            }
        }
    }
}