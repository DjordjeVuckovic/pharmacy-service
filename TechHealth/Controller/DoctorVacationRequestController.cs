using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class DoctorVacationRequestController
    {
        private readonly DoctorVacationRequestService doctorVacationRequestService = new DoctorVacationRequestService();

        public void CreateNotEmergentVacation(DoctorVacationRequest doctorVacationRequest)
        {
            doctorVacationRequestService.CreateNotEmergentVacation(doctorVacationRequest);
        }
        public void CreateEmergentVacation(DoctorVacationRequest doctorVacationRequest)
        {
            doctorVacationRequestService.CreateEmergentVacation(doctorVacationRequest);
        }
    }
}