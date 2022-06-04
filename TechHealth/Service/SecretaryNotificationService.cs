using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class SecretaryNotificationService
    {
        public bool Create(SecretaryNotification secretaryNotification)
        {
            return SecretaryNotificationRepository.Instance.Create(secretaryNotification);
        }
        public bool Delete(string id)
        {
            return SecretaryNotificationRepository.Instance.Delete(id);
        }
    }
}
