using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.RecommendationService
{
    internal interface IRecommendationStrategy
    {
        List<Appointment> GetRecommendedAppointments(); //ovde je mozda greska
    }
}
