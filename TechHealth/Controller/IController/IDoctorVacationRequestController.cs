using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Controller.IController
{
    public interface IDoctorVacationRequestController:IController<DoctorVacationRequest,string>
    {
        void CreateNotEmergentVacation(DoctorVacationRequest doctorVacationRequest);
        void CreateEmergentVacation(DoctorVacationRequest doctorVacationRequest);
        void ApproveOrRejectVacation(DoctorVacationRequest doctorVacationRequest, VacationStatus vacationStatus);
        List<DoctorVacationRequest> GetAllByDoctorId(string doctorId);
    }
}