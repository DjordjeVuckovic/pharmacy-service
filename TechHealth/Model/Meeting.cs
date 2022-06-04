using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class Meeting
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public Room Room { get; set; }
        public List<Person> Attendants { get; set; }
        public Meeting()
        {

        }
    }
}
