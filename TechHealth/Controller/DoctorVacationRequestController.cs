using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
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
        public List<DoctorVacationRequest> GetAll()
        {
            return doctorVacationRequestService.GetAll();
        }

        public List<DoctorVacationRequest> GetAllByDoctorId(string doctorId)
        {
            return doctorVacationRequestService.GetAllByDoctorId(doctorId);
        }
    }
}