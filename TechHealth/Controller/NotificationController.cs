using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.Controller
{
    class NotificationController
    {
        private NotificationService notificationService = new NotificationService();

        public List<Notification> GetAllNotification() => notificationService.GetAllNotification();

        public void UpdateNotification(Notification notification) => notificationService.UpdateNotification(notification);

        public void DeleteNotification(Notification notification) => notificationService.DeleteNotification(notification.ID);

        public void SaveNotification(Notification notification) => notificationService.SaveNotification(notification);

        public void DeleteNotification(string ID) => notificationService.DeleteNotification(ID);

        public Notification GetNotification(string key) => notificationService.GetNotification(key);

        public void SaveOrUpdate(Notification notification) => notificationService.SaveOrUpdate(notification);

        public List<Notification> ReadByUser(string userID)
        {
            return notificationService.ReadByUser(userID);
        }

        public List<Notification> ReadPastNotificationsByUser(string userID)
        {
            return notificationService.ReadPastNotificationsByUser(userID);
        }



    }
}