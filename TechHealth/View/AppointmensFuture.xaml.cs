using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service;
using TechHealth.View.PatientView;

namespace TechHealth.View
{
    public partial class AppointmensFuture : Window
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        private List<Doctor> doctors;
        private Patient patient;
        private Doctor doctor;
        public ObservableCollection<Appointment> Apt { get; set; }
        public static ObservableCollection<Appointment> MyList { get; set; }
        public AppointmensFuture(DateTime startDateRegion, DateTime finishDateRegion, Doctor doctor, Patient patient, Room room)
        {
            InitializeComponent();
            DataContext = this;
            doctors = DoctorRepository.Instance.GetAllToList();

            MyList = new ObservableCollection<Appointment>(appointmentService.GetAllFuture(startDateRegion, finishDateRegion, doctor, patient, room));
            patient = PatientRepository.Instance.GetPatientbyId("2456");

        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointmentt = MyList[RecommendedAppointmentsTable.SelectedIndex];
            appointmentt.IdAppointment = Guid.NewGuid().ToString("N");
            //appointmentt.Doctor = SuggestAppointment.
            //appointmentt.Doctor = MyList[RecommendedAppointmentsTable.SelectedIndex].Doctor;

            AppointmentRepository.Instance.Create(appointmentt);
            Close();
        }
    }
}
