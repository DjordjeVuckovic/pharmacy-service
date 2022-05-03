using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.RecommendationService
{
    class RecommendationService
    {
        IRecommendationStrategy recommendationStrategy;

        public RecommendationService()
        {


        }

        public List<Appointment> GetRecommendedAppointments()
        {
            return recommendationStrategy.GetRecommendedAppointments();
        }

        public void SetRecommendationStrategy(IRecommendationStrategy recommendationStrategy)
        {
            this.recommendationStrategy = recommendationStrategy;
        }



    }
}
