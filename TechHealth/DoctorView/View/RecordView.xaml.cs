using System.Windows.Controls;
using TechHealth.DoctorView.MedicalHistory;
using TechHealth.DoctorView.ViewModel;

namespace TechHealth.DoctorView.View
{
    public partial class RecordView : UserControl
    {
        public RecordView(string doctorId)
        {
            InitializeComponent();
            DataContext = new RecordViewModel(doctorId);

        }

        public RecordView()
        {
            InitializeComponent();
        }
    }
}