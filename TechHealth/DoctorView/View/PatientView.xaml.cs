using System.Windows.Controls;
using TechHealth.DoctorView.ViewModel;

namespace TechHealth.DoctorView.View
{
    public partial class PatientView : UserControl
    {
        public PatientView()
        {
            InitializeComponent();
            //DataContext = new PatientsViewModel();
        }
    }
}