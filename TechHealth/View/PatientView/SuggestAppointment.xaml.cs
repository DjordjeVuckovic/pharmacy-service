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
        private List<Doctor> doctors;
        private List<Appointment> apList;
        private ObservableCollection<Appointment> Apt { get; set; }
        private DateTime date;
        private Doctor doctor;
        private Patient patient;

        public SuggestAppointment(string patientId, ObservableCollection<Appointment> listAppointment)
        {
            InitializeComponent();
            DataContext = this;
            Apt = listAppointment;
            PatientData = patientController.GetByPatientId("2456");

            PatientFullName = PatientData.FullName;
            apList = AppointmentRepository.Instance.GetAllToList();


            //TxtPatient.Text = patient.FullName;
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
                Patient = PatientData,
                StartTimeD = DateTime.Parse(StartDates),
                FinishTimeD = DateTime.Parse(EndDate),
                //FinishDate = DateTime.Parse(FinishDate.Text),
                AppointmentType = AppointmentType.examination,
                Doctor = doctors[CbDoctor.SelectedIndex],
                Room = RoomData,
                IdAppointment = Guid.NewGuid().ToString("N"),
                ShouldSerialize = true
            };
            try //ako ima dostupnih datuma kod doktora, izlistaj
            {
                //new AppointmensFuture(Date, doctor, patientData).Show(); 
            }
            catch (AppointmentConflictException) //ako je doktor zauzet za neke datume, izlistaj dostupne na odnosu sta je stiklirano od prioriteta
            {
                new AppointmensFuture(Date, doctor, PatientData).Show();
            }
   
            Close();
        }

        public string PatientFullName { get; set; }

        public string StartDates { get; set; }
        public DateTime Date => date;

        public string EndDate { get; set; }

        public Patient PatientData { get; set; }
        public Room RoomData { get; set; }

        private void CheckedDoctor(object sender, RoutedEventArgs e)
        {

        }

        private void CheckedDate(object sender, RoutedEventArgs e)
        {

        }
    }
}
