using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class VacationNotification
    {
        public string Id { get; set; }
        public Doctor Doctor { get; set; }
        public string NotificationText { get; set; }
        public VacationNotification()
        {

        }
    }
}
