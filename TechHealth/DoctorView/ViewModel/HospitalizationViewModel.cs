using TechHealth.Core;

namespace TechHealth.DoctorView.ViewModel
{
    public class HospitalizationViewModel:ViewModelBase
    {
        public RelayCommand ExtendCommand { get; set; }
        public RelayCommand StatusCommand { get; set; }
        public HospitalizationViewModel()
        {
        }
    }
}