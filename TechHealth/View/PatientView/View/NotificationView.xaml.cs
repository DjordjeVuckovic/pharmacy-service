using System.Collections.Generic;
using System.Windows.Controls;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.PatientView.View
{
    /// <summary>
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    /// 
    public class NotificationWPF
    {

        Notification notif;
        string displayedImage;
        public NotificationWPF()
        {

        }
        public NotificationWPF(Notification not, string src)
        {
            notif = not;
            displayedImage = src;
        }

        public Notification Notif { get => notif; set => notif = value; }
    }


    public partial class NotificationView : UserControl
    {
        private List<Notification> notifications;
        private Patient patient;
        private string user;

        public NotificationView()
        {
            InitializeComponent();
            patient = PatientRepository.Instance.GetPatientByUser(user);
            notifications = new List<Notification>();
            NotificationController notifController = new NotificationController();
            notifications = notifController.ReadPastNotificationsByUser(patient.Jmbg);

            notifications.Reverse();
            List<NotificationWPF> notificationWPF = new List<NotificationWPF>();
            foreach (Notification notification in notifications)
            {
                notificationWPF.Add(new NotificationWPF(notification, ""));
            }
            viewerObavestenja.ItemsSource = notificationWPF;

            DataContext = notificationWPF;
        }


    }
}


