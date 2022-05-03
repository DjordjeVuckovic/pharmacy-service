using System.Windows;
using TechHealth.DoctorView;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.SecretaryView;

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
            Log();
        }

        private void Log()
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

            Secretary secretary = SecretaryRepository.Instance.GetSecretaryByUser(user);
            if (secretary != null && pass.Equals(secretary.Password))
            {
                new SecretaryMainWindow().Show();
                Close();
            }
        }

        public static string GetDoctorId()
        {
            return _doctorId;
        }


    }
}