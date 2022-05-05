using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;

namespace TechHealth.View
{
    public partial class AppointmensFuture : Window
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        private List<Doctor> doctors;
        public ObservableCollection<Appointment>MyList { get; set; }
        public AppointmensFuture(DateTime startDateRegion, DateTime finishDateRegion, Doctor doctor,Patient patient, Room room)
        {
            InitializeComponent();
            DataContext = this;
            doctors = DoctorRepository.Instance.GetAllToList();

            MyList = new ObservableCollection<Appointment>(appointmentService.GetAllFuture(startDateRegion, finishDateRegion, doctor, patient, room));
            
        }
    }
}