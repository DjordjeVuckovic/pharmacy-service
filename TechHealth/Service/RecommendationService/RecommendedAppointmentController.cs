using System.Collections.Generic;
using TechHealth.DTO;
using TechHealth.Model;

namespace TechHealth.Service.RecommendationService
{
    class RecommendedAppointmentController
    {

        private RecommendationService recomendationService;
        public RecommendedAppointmentController()
        {
            recomendationService = new RecommendationService();
        }

        public List<Appointment> GetRecommendedAppointments(RecommendedAppointmentDTO recommendedAppointmentDto)
        {
            if (recommendedAppointmentDto.DoctorID == null)
            {
                return DateRecommendation(recommendedAppointmentDto);
            }
            else
            {
                return DoctorRecommendataion(recommendedAppointmentDto);
            }
        }
        public List<Appointment> DateRecommendation(RecommendedAppointmentDTO recommendedAppointmentDTO)
        {
            recomendationService.SetRecommendationStrategy(new DateRecommendationStrategy(recommendedAppointmentDTO.StartDate, recommendedAppointmentDTO.EndDate, recommendedAppointmentDTO.PatientID));
            return recomendationService.GetRecommendedAppointments();
        }

        public List<Appointment> DoctorRecommendataion(RecommendedAppointmentDTO recommendedAppointmentDTO)
        {
            recomendationService.SetRecommendationStrategy(new DoctorRecommendationStrategy(recommendedAppointmentDTO));
            return recomendationService.GetRecommendedAppointments();
        }
    }
}
