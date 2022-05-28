using System.Collections.ObjectModel;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class VacationHistoryViewModel:ViewModelBase
    {
        private readonly DoctorVacationRequestController doctorVacationRequestController =
            new DoctorVacationRequestController();

        private DoctorVacationRequest selectedVacation;
        private ObservableCollection<DoctorVacationRequest> vacations;
        public ObservableCollection<DoctorVacationRequest> Vacations
        {
            get => vacations;
            set
            {
                vacations = value;
                OnPropertyChanged(nameof(Vacations));
            }
            
        }
        public RelayCommand DetailsCommand { get; set; }

        public DoctorVacationRequest SelectedVacation
        {
            get => selectedVacation;
            set => selectedVacation = value;
        }

        public VacationHistoryViewModel(Doctor doctor)
        {
            Vacations = new ObservableCollection<DoctorVacationRequest>(doctorVacationRequestController.GetAllByDoctorId(doctor.Jmbg));
        }

        private void ExecuteDetails()
        {
            
        }

        private bool CanExecuteDetails()
        {
            if (SelectedVacation == null)
            {
                return false;
            }

            return true;
        }
    }
}