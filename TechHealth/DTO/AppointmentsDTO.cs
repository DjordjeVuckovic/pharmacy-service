using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.DTO
{
    public class AppointmentsDTO
    {
        public string idAppointment { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string doctor { get; set; }
        public string patient { get; set; }
        public string room { get; set; }

        public AppointmentsDTO()
        {
        }
        public AppointmentsDTO(string id, DateTime start, DateTime end, string doctor, string patient, string room)
        {
            this.idAppointment = id;
            this.start = start;
            this.end = end;
            this.doctor = doctor;
            this.patient = patient;
            this.room = room;
        }
    }
}
