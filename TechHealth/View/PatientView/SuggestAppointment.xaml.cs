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
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

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
        public RelayCommand FinishCommand { get; set; }
        private Patient patient;

        public SuggestAppointment(string patientId, ObservableCollection<Appointment> listAppointment)
        {
            InitializeComponent();
            DataContext = this;
            Apt = listAppointment;

            patient = patientController.GetByPatientId("2456");
            PatientFullName = patient.FullName;
            StartDatePicker.SelectedDate = DateTime.Now;
            StartDatePicker.DisplayDateStart = DateTime.Now;
            FinishDatePicker.DisplayDateStart = DateTime.Now;
            FinishDatePicker.SelectedDate = DateTime.Now.AddDays(1);
            room = roomController.GetById("S2");
            //apList = AppointmentRepository.Instance.GetAllToList();
            //doctor = DoctorRepository.Instance.GetDoctorbyId("2315");
            doctors = DoctorRepository.Instance.GetAllToList();
            CbDoctor.ItemsSource = doctors;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
        }

        private bool CanExecute()
        {
            if (CbDoctor.SelectedItem != null)
            {
                if (StartDatePicker.SelectedDate < FinishDatePicker.SelectedDate)
                    return true;
            }
            return false;
        }

        private void Execute()
        {
            Appointment appointment = new Appointment
            {
                AppointmentType = AppointmentType.examination,

                //StartDateRegion = DateTime.Parse(StartDatePicker.Text),
                //FinishDateRegion = DateTime.Parse(FinishDatePicker.Text),
                Doctor = doctors[CbDoctor.SelectedIndex],
                Emergent = false,
                Evident = false,
                IdAppointment = Guid.NewGuid().ToString("N"),
                Patient = patient,
                Room = room,

                //ShouldSerialize = true
            };

            try //ako ima dostupnih datuma kod doktora, izlistaj
            {
                new AppointmensFuture(DateTime.Parse(StartDatePicker.Text), DateTime.Parse(FinishDatePicker.Text), appointment.Doctor, appointment.Patient, appointment.Room).Show();
            }
            catch (AppointmentConflictException) //ako je doktor zauzet za neke datume, izlistaj dostupne na odnosu sta je stiklirano od prioriteta
            {
                /*Appointment ap = new Appointment();
                ap.StartDateRegion = DateTime.Parse(StartDatePicker.Text);
                ap.FinishDateRegion = DateTime.Parse(FinishDatePicker.Text);*/
                //new AppointmensFuture(StartDateRegion, FinishDateRegion, doctor, PatientData).Show();
                MessageBox.Show(@"Doctor has booked an appointment in that period!", @"Appointment exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
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

                //StartDateRegion = DateTime.Parse(StartDatePicker.Text),
                //FinishDateRegion = DateTime.Parse(FinishDatePicker.Text),
                Doctor = doctors[CbDoctor.SelectedIndex],
                Emergent = false,
                IdAppointment = Guid.NewGuid().ToString("N"),
                Patient = patient,
                Room = room,
                //ShouldSerialize = true
            };

            try //ako ima dostupnih datuma kod doktora, izlistaj
            {
                new AppointmensFuture(DateTime.Parse(StartDatePicker.Text), DateTime.Parse(FinishDatePicker.Text), appointment.Doctor, appointment.Patient, appointment.Room).Show();
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
