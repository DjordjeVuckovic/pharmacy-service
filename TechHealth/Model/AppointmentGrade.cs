using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class AppointmentGrade
    {
        public string Id { get; set; }
        public int OcenaLekara { get; set; } // OVDE OCENE ZA LEKARA
        public int OcenaOsoblje { get; set; }
        public int UkupnaOcena { get; set; }
        public Appointment EvidentAppointment { get; set; }

    }
}