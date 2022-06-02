using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class VacationNotificationService
    {
        public bool Create(VacationNotification vacationNotification)
        {
            return VacationNotificationRepository.Instance.Create(vacationNotification);
        }
        public bool Delete(string id)
        {
            return VacationNotificationRepository.Instance.Delete(id);
        }
    }
}
