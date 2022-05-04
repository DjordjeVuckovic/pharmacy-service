using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.RecommendationService
{
    class DateRecommendationStrategy : IRecommendationStrategy
    {

        string patientID;
        List<AppointmentDraft> recommendedAppointementsDrafts;


        public DateRecommendationStrategy(DateTime startDate, DateTime endDate, string patientID)
        {
            recommendedAppointementsDrafts = new List<AppointmentDraft>();

            this.patientID = patientID;
            recommendedAppointementsDrafts = new AppointmentDraftPreparation(startDate, endDate).GetRecommendedAppointmentDrafts();
        }

        public List<Appointment> GetRecommendedAppointments()
        {
            RemoveReservedAppointments();
            ITransformDraftToAppointment transformDraftToAppointment = new DateDraft();
            return transformDraftToAppointment.TransformDraftToAppointment(recommendedAppointementsDrafts, patientID, "");

        }

        private void RemoveBusyDoctors(Appointment appointment)
        {

            for (int i = 0; i < recommendedAppointementsDrafts.Count; i++)
            {

                if (recommendedAppointementsDrafts[i].TimeOfAppointment.Equals(appointment.StartTime))
                {
                    recommendedAppointementsDrafts[i].AvailableDoctorsID.Remove(appointment.Doctor.Jmbg);

                }
            }
        }

        private void RemoveReservedAppointments()
        {
            List<Appointment> scheduledAppointments = new AppointmentService().GetFutureAppointments();
            for (int i = 0; i < scheduledAppointments.Count; i++)
            {

                RemoveBusyDoctors(scheduledAppointments[i]);
            }
            RemoveAppointmentsWithoutDoctors();
        }


        private void RemoveAppointmentsWithoutDoctors()
        {
            for (int i = 0; i < recommendedAppointementsDrafts.Count; i++)
            {
                if (recommendedAppointementsDrafts[i].AvailableDoctorsID.Count == 0)
                {
                    recommendedAppointementsDrafts.RemoveAt(i);
                    i--;
                }
            }
        }
 

    }
}
