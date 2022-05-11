using System.Collections.Generic;
using TechHealth.Exceptions;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class DoctorVacationRequestService
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        public List<DoctorVacationRequest> GetAll()
        {
            List<DoctorVacationRequest> vacationRequests = DoctorVacationRequestRepository.Instance.GetAllToList();
            BindDataForDoctor(vacationRequests);
            return vacationRequests;
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
            foreach (var existingAppointment in appointmentService.GetAllNotEvident(newVacation.Doctor.Jmbg))
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
                vac.Doctor = DoctorRepository.Instance.GetDoctorbyId(vac.Doctor.Jmbg);
            }
        }

        
    }
}