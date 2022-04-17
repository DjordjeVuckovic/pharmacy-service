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
        private static string _doctorId;
        private static LoginWindow _instance;
        
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
                //AppointmentsWindow.GetInstance(doctor.Jmbg).Show();
                _doctorId = doctor.Jmbg;
                new DoctorWindow(doctor.Jmbg).Show();
                Close();
            }
        }

        public static string GetDoctorId()
        {
            return _doctorId;
        }

        
    }
}