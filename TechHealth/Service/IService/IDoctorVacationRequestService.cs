using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IDoctorVacationRequestService:IService<DoctorVacationRequest,string>
    {
        void ApproveOrRejectVacation(DoctorVacationRequest doctorVacationRequest);
        void CreateNotEmergentVacation(DoctorVacationRequest doctorVacationRequest);
        void CreateEmergentVacation(DoctorVacationRequest doctorVacationRequest);
        List<DoctorVacationRequest> GetAllByDoctorId(string doctorId);
    }
}