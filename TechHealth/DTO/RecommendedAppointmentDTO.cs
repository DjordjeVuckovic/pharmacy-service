using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.DTO
{
    class RecommendedAppointmentDTO
    {
        public PatientRecommendType Type { get; set; }
        public string DoctorID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PatientID { get; set; }

        public RecommendedAppointmentDTO(PatientRecommendType type, String doctorId, DateTime startDate,
            DateTime endDate, String patientId)
        {
            Type = type;
            DoctorID = doctorId;
            StartDate = startDate;
            EndDate = endDate;
            PatientID = patientId;
        }
    }
}
