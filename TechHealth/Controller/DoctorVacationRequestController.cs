using System.Collections.Generic;
using TechHealth.Controller.IController;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class DoctorVacationRequestController:IDoctorController
    {
        private readonly IDoctorVacationRequestService doctorVacationRequestService = new DoctorVacationRequestService();

        public void CreateNotEmergentVacation(DoctorVacationRequest doctorVacationRequest) => doctorVacationRequestService.CreateNotEmergentVacation(doctorVacationRequest);
        public void CreateEmergentVacation(DoctorVacationRequest doctorVacationRequest) => doctorVacationRequestService.CreateEmergentVacation(doctorVacationRequest);
        public List<DoctorVacationRequest> GetAll() => doctorVacationRequestService.GetAll();
        public void Create(Doctor entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Doctor entity)
        {
            throw new System.NotImplementedException();
        }

        public Doctor GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public List<Doctor> GetAllBySpecializationId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ApproveOrRejectVacation(DoctorVacationRequest doctorVacationRequest, VacationStatus vacationStatus)
        {
            doctorVacationRequest.VacationStatus = vacationStatus;
            doctorVacationRequestService.ApproveOrRejectVacation(doctorVacationRequest);
        }
        public List<DoctorVacationRequest> GetAllByDoctorId(string doctorId) => doctorVacationRequestService.GetAllByDoctorId(doctorId);
        List<Doctor> IController<Doctor, string>.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}