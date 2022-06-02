using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class VacationNotificationController
    {
        private VacationNotificationService vacationNotificationService = new VacationNotificationService();
        public bool Create(VacationNotification vacationNotification)
        {
            return vacationNotificationService.Create(vacationNotification);
        }
        public bool Delete(string id)
        {
            return vacationNotificationService.Delete(id);
        }
    }
}
