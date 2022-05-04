using System;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.View
{
    public partial class AppointmensFuture : Window
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        public ObservableCollection<Appointment>MyList { get; set; }
        public AppointmensFuture(DateTime startDate,Doctor doctor,Patient patient)
        {
            InitializeComponent();
            DataContext = this;
            MyList = new ObservableCollection<Appointment>(appointmentService.GetAllFuture(startDate, doctor, patient));
        }
    }
}