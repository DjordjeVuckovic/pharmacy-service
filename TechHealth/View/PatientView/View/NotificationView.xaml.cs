﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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


        public NotificationView()
        {
            InitializeComponent();
            patient = PatientRepository.Instance.GetPatientbyId(patient.Jmbg);
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
    

