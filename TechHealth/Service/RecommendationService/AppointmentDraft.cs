using System;
using System.Collections.Generic;

namespace TechHealth.Service.RecommendationService
{
    class AppointmentDraft
    {

        private List<string> availableDoctorsID;
        private DateTime timeOfAppointment;
        public AppointmentDraft()
        {

        }
        public AppointmentDraft(DateTime time)
        {
            timeOfAppointment = time;
            availableDoctorsID = new DoctorService().GetExaminationDoctorsID();
        }

        public List<string> AvailableDoctorsID { get => availableDoctorsID; set => availableDoctorsID = value; }
        public DateTime TimeOfAppointment { get => timeOfAppointment; set => timeOfAppointment = value; }
    }
}
