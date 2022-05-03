using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
    interface INotificationRepository : IGenericRepository<Notification, string>
    {
        List<Notification> ReadByUser(string key);
        List<Notification> ReadPastNotificationsByUser(string key);
    }
}
