using System;
using System.Collections.Generic;
using TechHealth.DTO;
using TechHealth.Model;

namespace TechHealth.Service.RecommendationService
{
    class DoctorRecommendationStrategy : IRecommendationStrategy
    {

        DateTime startDate;
        DateTime endDate;
        string doctorID;
        string patientID;
        List<AppointmentDraft> recommendedAppointementsDrafts;


        public DoctorRecommendationStrategy(RecommendedAppointmentDTO recommendedAppointmentDto)
        {
            recommendedAppointementsDrafts = new List<AppointmentDraft>();
            this.startDate = recommendedAppointmentDto.StartDate;
            this.endDate = recommendedAppointmentDto.EndDate;
            this.doctorID = recommendedAppointmentDto.DoctorID;
            this.patientID = recommendedAppointmentDto.PatientID;
            recommendedAppointementsDrafts = new AppointmentDraftPreparation(startDate, endDate).GetRecommendedAppointmentDrafts();

        }

        private void RemoveReservedAppointments()
        {
            AppointmentService appointmentService = new AppointmentService();
            foreach (var appointment in appointmentService.GetFutureAppointments())
            {
                if (appointment.Doctor.Jmbg == doctorID || appointment.Patient.Jmbg == patientID)
                {
                    DeleteFromAppointmentsDraft(appointment);
                }
            }
        }


        private void DeleteFromAppointmentsDraft(Appointment appointment)
        {
            RoomService roomAvailabilityService = new RoomService();
            for (int i = 0; i < recommendedAppointementsDrafts.Count; i++)
            {
                if (appointment.SameStartTime(recommendedAppointementsDrafts[i].TimeOfAppointment)) //|| !RoomService.IsFreeRoomExists(recommendedAppointementsDrafts[i].TimeOfAppointment))
                    recommendedAppointementsDrafts.RemoveAt(i);
            }
        }

        public List<Appointment> GetRecommendedAppointments()
        {
            RemoveReservedAppointments();
            ITransformDraftToAppointment transformDraftToAppointment = new DoctorRecommendationDraftsTransformation();
            return transformDraftToAppointment.TransformDraftToAppointment(recommendedAppointementsDrafts, patientID, doctorID);
        }
    }
}
