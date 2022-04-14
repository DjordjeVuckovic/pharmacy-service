using System;
using System.Linq;
using System.Windows;
using TechHealth.DoctorView;
using TechHealth.Model;
using TechHealth.Repository;

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
            Doctor doctor = DoctorRepository.Instance.GetDoctorByUser(user);
            if (doctor != null && pass.Equals(doctor.Password))
            {
                DoctorMainWindow.GetInstance(doctor.Jmbg).Show();
                Close();
            }
        }

        
    }
}