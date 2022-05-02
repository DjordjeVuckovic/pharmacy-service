using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    interface INotificationRepository : IGenericRepository<Notification, string>
    {
        List<Notification> ReadByUser(string key);
        List<Notification> ReadPastNotificationsByUser(string key);
    }
}
