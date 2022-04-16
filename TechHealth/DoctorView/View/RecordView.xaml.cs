using System.Windows.Controls;
using TechHealth.DoctorView.MedicalHistory;
using TechHealth.DoctorView.ViewModel;

namespace TechHealth.DoctorView.View
{
    public partial class RecordView : UserControl
    {
        public RecordView(string id)
        {
            InitializeComponent();
            DataContext = new RecordViewModel(id);

        }
        
    }
}