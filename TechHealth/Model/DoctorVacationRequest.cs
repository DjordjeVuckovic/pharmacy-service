using System;

namespace TechHealth.Model
{
    public class DoctorVacationRequest
    {
        public string VacationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Doctor Doctor { get; set; }
        public string VacationReason { get; set; }
        public bool Emergent { get; set; }
        public VacationStatus VacationStatus { get; set; }
        
        public bool CheckDaysConflict(DoctorVacationRequest doctorVacationRequest)
        {
            
            return doctorVacationRequest.StartDate < FinishDate && doctorVacationRequest.FinishDate > StartDate;
        }
        
    }
}