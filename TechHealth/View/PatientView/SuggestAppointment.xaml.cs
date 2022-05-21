using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TechHealth.Exceptions;
using TechHealth.Model;
using TechHealth.Core;
using TechHealth.Repository;

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for SuggestAppointment.xaml
    /// </summary>
    /// 

    public partial class SuggestAppointment : Window  //da li ovde treba user control
    {
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private RoomController roomController = new RoomController();
        private List<Doctor> doctors;
        private List<Appointment> apList;
        private ObservableCollection<Appointment> Apt { get; set; }
        private Doctor doctor;
        private Room room;

        private Patient patient;

        public SuggestAppointment(string patientId, ObservableCollection<Appointment> listAppointment)
        {
            InitializeComponent();
            DataContext = this;
            Apt = listAppointment;

            patient = patientController.GetByPatientId("2456");
            PatientFullName = patient.FullName;

            room = roomController.GetById("S2");
            //apList = AppointmentRepository.Instance.GetAllToList();
            //doctor = DoctorRepository.Instance.GetDoctorbyId("2315");
            doctors = DoctorRepository.Instance.GetAllToList();
            CbDoctor.ItemsSource = doctors;
        }

        public SuggestAppointment(Patient patient)
        {
            this.patient = patient;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment
            {
                AppointmentType = AppointmentType.examination,
                StartDateRegion = DateTime.Parse(StartDatePicker.Text),
                FinishDateRegion = DateTime.Parse(FinishDatePicker.Text),
                Doctor = doctors[CbDoctor.SelectedIndex],
                Emergent = false,
                IdAppointment = Guid.NewGuid().ToString("N"),
                Patient = patient,
                Room = room,
                //ShouldSerialize = true
            };

            try //ako ima dostupnih datuma kod doktora, izlistaj
            {
                new AppointmensFuture(appointment.StartDateRegion, appointment.FinishDateRegion, appointment.Doctor, appointment.Patient, appointment.Room).Show();
            }
            catch (AppointmentConflictException) //ako je doktor zauzet za neke datume, izlistaj dostupne na odnosu sta je stiklirano od prioriteta
            {
                /*Appointment ap = new Appointment();
                ap.StartDateRegion = DateTime.Parse(StartDatePicker.Text);
                ap.FinishDateRegion = DateTime.Parse(FinishDatePicker.Text);*/
                //new AppointmensFuture(StartDateRegion, FinishDateRegion, doctor, PatientData).Show();
            }
   
            Close();
        }

        public string PatientFullName { get; set; }

        //public Patient PatientData { get; set; }
        //public Room RoomData { get; set; }
        //public DateTime StartDateRegion { get=>DateTime.Parse(StartDatePicker.Text); set { } }
        //public DateTime FinishDateRegion { get => DateTime.Parse(FinishDatePicker.Text); set { } }

        

    }

}
