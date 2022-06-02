using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class SecretaryNotificationController
    {
        private SecretaryNotificationService secretaryNotificationService = new SecretaryNotificationService();
        public bool Create(SecretaryNotification secretaryNotification)
        {
            return secretaryNotificationService.Create(secretaryNotification);
        }
        public bool Delete(string id)
        {
            return secretaryNotificationService.Delete(id);
        }
    }
}
