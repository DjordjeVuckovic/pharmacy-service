using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class PatientNotificationService
    {
        public bool Create(PatientNotification patientNotif)
        {
            return PatientNotificationRepository.Instance.Create(patientNotif);
        }
        public bool Delete(string id)
        {
            return PatientNotificationRepository.Instance.Delete(id);
        }
    }
}
