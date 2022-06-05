using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class HospitalGrade
    {
        public string Id { get; set; }
        public int OcenaCistoca { get; set; }
        public int OcenaDostupnost { get; set; }
        public int OcenaOprema { get; set; }
        public int OcenaLakoca { get; set; }
        public Patient LoggedPatient { get; set; }

    }
}
