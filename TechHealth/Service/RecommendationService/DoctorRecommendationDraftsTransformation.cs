using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service.RecommendationService
{
    class DoctorRecommendationDraftsTransformation : ITransformDraftToAppointment
    {
        public List<Appointment> TransformDraftToAppointment(List<AppointmentDraft> recommendedAppointmentsDraft, string patientID, string doctorID)
        {
            //DoctorRepository DoctorRepository = new DoctorRepository();
            //PatientRepository patientRepository = PatientRepository;
            //RoomService roomService = new RoomAvailabilityService();
            List<Appointment> recommendedAppointments = new List<Appointment>();
            for (int i = 0; i < recommendedAppointmentsDraft.Count && i < 5; i++)
            {
                recommendedAppointments.Add(new Appointment(recommendedAppointmentsDraft[i].TimeOfAppointment,                
                                                        AppointmentType.examination,
                                                        DoctorRepository.Instance.GetDoctorbyId(doctorID),
                                                        PatientRepository.Instance.GetPatientbyId(patientID),
                                                        RoomRepository.Instance.GetAvailableRooms(recommendedAppointmentsDraft[i].TimeOfAppointment)[0]));
            }
            return recommendedAppointments;
        }
    }
}