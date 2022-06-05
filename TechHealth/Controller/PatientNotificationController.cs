using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class PatientNotificationController
    {
        private PatientNotificationService patientNotificationService = new PatientNotificationService();
        public bool Create(PatientNotification patientNotification)
        {
            return patientNotificationService.Create(patientNotification);
        }
        public bool Delete(string id)
        {
            return patientNotificationService.Delete(id);
        }
    }
}
