using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Controller;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.DoctorView.ViewModel
{
    public class DoctorNotificationsViewModel:ViewModelBase
    {
        public ObservableCollection<SecretaryNotification> Notifications { get; set; }

        private readonly SecretaryNotificationController secretaryNotificationController =
            new SecretaryNotificationController();

        public DoctorNotificationsViewModel()
        {
            BindDataForNotifications();
        }
        private void BindDataForNotifications()
        {
            List<SecretaryNotification> notificationList = secretaryNotificationController.GetByPersonId(MainViewModel.DoctorId);
            notificationList.Reverse();
            Notifications = new ObservableCollection<SecretaryNotification>(notificationList);
        }
    }
}