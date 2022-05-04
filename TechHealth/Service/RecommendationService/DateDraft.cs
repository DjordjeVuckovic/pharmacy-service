using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service.RecommendationService
{
    class DateDraft : ITransformDraftToAppointment
    {

        public List<Appointment> TransformDraftToAppointment(List<AppointmentDraft> recommendedAppointmentsDraft,string patientID,string doctorID)
        {
            //DoctorRepository doctorRepository = new DoctorRepository();
            //IPatientRepository patientRepository = new PatientFileRepository();
            //RoomAvailabilityService roomService = new RoomAvailabilityService();*/
            List<Appointment> recommendedAppointments = new List<Appointment>();
            for (int i = 0; i < recommendedAppointmentsDraft.Count && i < 5; i++)
            {
                recommendedAppointments.Add(new Appointment(recommendedAppointmentsDraft[i].TimeOfAppointment,
                                                        AppointmentType.examination,
                                                        DoctorRepository.Instance.GetById(recommendedAppointmentsDraft[i].AvailableDoctorsID[0]),
                                                        PatientRepository.Instance.GetPatientById(patientID),
                                                        RoomRepository.Instance.GetAvailableRooms(recommendedAppointmentsDraft[i].TimeOfAppointment)[0]));
            }
            return recommendedAppointments;
        }
    }
}
