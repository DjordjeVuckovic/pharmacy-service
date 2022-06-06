using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TechHealth.Controller;
using TechHealth.DoctorView.ViewModel;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.DoctorView.View
{
    public partial class NotificationView : UserControl
    {
        private ObservableCollection<SecretaryNotification> notifications;

        private readonly SecretaryNotificationController secretaryNotificationController =
            new SecretaryNotificationController();
        public NotificationView()
        {
            InitializeComponent();
            BindDataForNotifications();
            NotificationViewer.ItemsSource = notifications;
        }
        private void BindDataForNotifications()
        {
            List<SecretaryNotification> notificationList = secretaryNotificationController.GetByPersonId(MainViewModel.DoctorId);
            notificationList.Reverse();
            notifications = new ObservableCollection<SecretaryNotification>(notificationList);
        }
    }
}