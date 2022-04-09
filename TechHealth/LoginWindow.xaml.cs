using System;
using System.Linq;
using System.Windows;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.DoctorView;

namespace TechHealth
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DoctorLog();
        }

        private void DoctorLog()
        {
            string user = Username.Text;
            string pass = Password.Password;
            Doctor doctor = DoctorRepository.Instance.GetDoctor(user);
            if (doctor != null && pass.Equals(doctor.Password))
            {
                DoctorMainWindow window = new DoctorMainWindow();
                window.Show();
                Close();
            }
            
            
        }
    }
}