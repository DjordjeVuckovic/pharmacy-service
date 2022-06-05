using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class PatientNotification
    {
        public string Id { get; set; }
        public Person Person { get; set; }
        public string Text { get; set; }
        public PatientNotification()
        {
        }
    }
}
