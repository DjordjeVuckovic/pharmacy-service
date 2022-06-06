using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class DoctorVacationRequestController
    {
        private readonly IDoctorVacationRequestService doctorVacationRequestService = new DoctorVacationRequestService();

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
        public void ApproveOrRejectVacation(DoctorVacationRequest doctorVacationRequest, VacationStatus vacationStatus)
        {
            doctorVacationRequest.VacationStatus = vacationStatus;
            doctorVacationRequestService.ApproveOrRejectVacation(doctorVacationRequest);
        }
        public List<DoctorVacationRequest> GetAllByDoctorId(string doctorId)
        {
            return doctorVacationRequestService.GetAllByDoctorId(doctorId);
        }
    }
}