using System.Windows;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.ViewModel;

namespace TechHealth.DoctorView
{
    public partial class DoctorWindow : Window
    {
        private static string _doctorId;
        // public DoctorWindow()
        // {
        //     //DataContext = new MainViewModel();
        //     InitializeComponent();
        // }

        public DoctorWindow(string doctorJmbg)
        {
            InitializeComponent();
            DataContext = new MainViewModel(doctorJmbg);
            _doctorId = doctorJmbg;
        }
        public static string GetDoctorId()
        {
            return _doctorId;
        }
    }
}