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
            throw new NotImplementedException();
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
    }
}
