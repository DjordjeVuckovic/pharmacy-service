using System.Collections.Generic;
using TechHealth.Exceptions;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class DoctorVacationRequestService:IDoctorVacationRequestService
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        public List<DoctorVacationRequest> GetAll()
        {
            List<DoctorVacationRequest> vacationRequests = DoctorVacationRequestRepository.Instance.GetAllToList();
            BindDataForDoctor(vacationRequests);
            return vacationRequests;
        }

        public bool Create(DoctorVacationRequest entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(DoctorVacationRequest entity)
        {
            throw new System.NotImplementedException();
        }

        public DoctorVacationRequest GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public void ApproveOrRejectVacation(DoctorVacationRequest doctorVacationRequest)
        {
            DoctorVacationRequestRepository.Instance.Update(doctorVacationRequest);
        }
        public void CreateNotEmergentVacation(DoctorVacationRequest doctorVacationRequest)
        {
            CheckAvailabilityForSpecialization(doctorVacationRequest);
            CompareAppointmentVacationDays(doctorVacationRequest);
            DoctorVacationRequestRepository.Instance.Create(doctorVacationRequest);
        }
        public void CreateEmergentVacation(DoctorVacationRequest doctorVacationRequest)
        {
            CompareAppointmentVacationDays(doctorVacationRequest);
            DoctorVacationRequestRepository.Instance.Create(doctorVacationRequest);
        }

        private void CheckAvailabilityForSpecialization(DoctorVacationRequest doctorVacationRequest)
        {
            if(doctorVacationRequest.VacationStatus == VacationStatus.Approved || doctorVacationRequest.VacationStatus ==VacationStatus.Waiting) 
                ThrowSpecializationException(doctorVacationRequest);
        }

        private void ThrowSpecializationException(DoctorVacationRequest newVacation)
        {
            if (SpecializationConflict(newVacation))
            {
                throw new SpecializationException();
            }
        }

        private void CompareAppointmentVacationDays(DoctorVacationRequest newVacation)
        {
            if (AppointmentsVacationConflict(newVacation))
            {
                throw new AppointmentVacationException();
            }
        }

        private bool AppointmentsVacationConflict(DoctorVacationRequest newVacation)
        {
            bool isConflict = false;
            foreach (var existingAppointment in appointmentService.GetAllNotEvidentByDoctorId(newVacation.Doctor.Jmbg))
            {
                if (existingAppointment.Date >= newVacation.StartDate && existingAppointment.Date <= newVacation.FinishDate)
                    isConflict = true;
            }

            return isConflict;
        }

        private bool SpecializationConflict(DoctorVacationRequest newVacation)
        {
            var specializationCounter = SpecializationConflictCounter(newVacation);
            return specializationCounter > 1;
        }

        private int SpecializationConflictCounter(DoctorVacationRequest newVacation)
        {
            int specializationCounter = 0;
            foreach (var existingVacation in GetAll())
            {
                if (existingVacation.Doctor.Specialization.IdSpecialization ==
                    newVacation.Doctor.Specialization.IdSpecialization && existingVacation.CheckDaysConflict(newVacation))
                {
                    specializationCounter++;
                }
            }

            return specializationCounter;
        }


        private void BindDataForDoctor(List<DoctorVacationRequest> doctorVacationRequests)
        {
            foreach (var vac in doctorVacationRequests)
            {
                vac.Doctor = DoctorRepository.Instance.GetDoctorById(vac.Doctor.Jmbg);
            }
        }

        public List<DoctorVacationRequest> GetAllByDoctorId(string doctorId)
        {
            List<DoctorVacationRequest> doctorVacationRequests = new List<DoctorVacationRequest>();
            foreach (var doctorVacationRequest in GetAll())
            {
                if (doctorVacationRequest.Doctor.Jmbg.Equals(doctorId))
                {
                    doctorVacationRequests.Add(doctorVacationRequest);
                }
            }

            return doctorVacationRequests;
        }


    }
}