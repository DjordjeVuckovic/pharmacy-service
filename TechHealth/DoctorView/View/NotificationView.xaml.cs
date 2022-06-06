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
        
        public NotificationView()
        {
            InitializeComponent();
            var vm = new DoctorNotificationsViewModel();
            DataContext = vm;
        }
        
    }
}