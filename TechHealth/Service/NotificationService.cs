using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    class NotificationService
    {
        private NotificationFileRepository notificationRepository = new NotificationFileRepository();

        public NotificationService()
        {
        }
        public List<Notification> GetAllNotification() => notificationRepository.GetAllToList();

        public void UpdateNotification(Notification notification) => notificationRepository.Update(notification);

        public void DeleteNotification(Notification notification) => notificationRepository.Delete(notification.ID);

        //public void SaveNotification(Notification notification) => notificationRepository.Save(notification);

        public void DeleteNotification(string ID) => notificationRepository.Delete(ID);

        public Notification GetNotification(string key) => notificationRepository.GetById(key);

        public void SaveOrUpdate(Notification notification) => notificationRepository.Create(notification);

        public List<Notification> ReadByUser(string userID)
        {
            return notificationRepository.ReadByUser(userID);
        }

        public List<Notification> ReadPastNotificationsByUser(string userID)
        {
            return notificationRepository.ReadPastNotificationsByUser(userID);
        }
    }
}