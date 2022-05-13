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
        public int OcenaOsoblje { get; set; }
        public int OcenaSpremnost { get; set; }
        public int OcenaCistoca { get; set; }
        public int OcenaOprema { get; set; }
        public int UkupnaOcena { get; set; }
        public Patient Patient { get; set; }

    }
}
