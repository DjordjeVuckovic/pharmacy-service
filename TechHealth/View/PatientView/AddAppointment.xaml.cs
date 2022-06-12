using System;
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
using TechHealth.Model;
using TechHealth.Controller;
using TechHealth.Repository;
using System.Collections.ObjectModel;
using TechHealth.Exceptions;
using TechHealth.Core;
using System.Windows.Forms;
using TechHealth.DoctorView.ViewModel;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TechHealth.View.PatientView       //dodati IDappointment
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {

        public event EventHandler OnRequestClose;
        private Doctor doctor;
        private Patient patient;
        private Room room;
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private RoomController roomController = new RoomController();
        private DoctorController doctorController = new DoctorController();
        private List<Doctor> doctors;
        private List<Appointment> apList;
        private ObservableCollection<Appointment> Apt { get; set; }
        public DateTime Date { get; set; }
        public string StartDate { get; set; }
        //public Doctor DoctorData { get; set; }

        public RelayCommand FinishCommand { get; set; }
        //public RelayCommand CancelCommand { get; set; }
        //private String patientId { get; set; }

        public AddAppointment(ObservableCollection<Appointment> listAppointment)
        {
            InitializeComponent();
            DataContext = this;
            Apt = listAppointment;
            patient = patientController.GetByPatientId("2456");
            room = roomController.GetById("S2");
            PatientFullName = patient.FullName;
            apList = AppointmentRepository.Instance.GetAllToList();
            Picker.DisplayDateStart = DateTime.Now;
            Picker.SelectedDate = DateTime.Now;
            Timepicker1.SelectedTime = DateTime.Now;
            //Date = DateTime.Now;
            FinishCommand = new RelayCommand(param => Execute(), param => CanExecute());
            //TxtPatient.Text = patient.FullName;
            doctors = DoctorRepository.Instance.GetAllToList();
            CbDoctor.ItemsSource = doctors;
        }


        private bool CanExecute()
        {
            if (StartDate != null && CbDoctor.SelectedItem != null)
            {
                return true;
            }
            return false;
        }

        private void Execute()
        {
            Appointment appointment = new Appointment
            {
                AppointmentType = AppointmentType.examination,
                Date = Date,
                Patient = patient,
                Evident = false,
                Emergent = false,
                Graded = false,
                StartTime = DateTime.Parse(StartDate),
                IdAppointment = Guid.NewGuid().ToString("N"),
                Doctor = doctors[CbDoctor.SelectedIndex],
                ShouldSerialize = true,
                Room = room
            };
            try
            {
                appointmentController.Create(appointment);
                Apt.Add(appointment);
                
                //RecordViewModel.GetInstance().Appointments.Add(appointment);
                MessageBox.Show(@"You have successfully created a new examination");
                Close();
            }
            catch (AppointmentConflictException)
            {
                MessageBox.Show(@"Patient has already booked an appointment in that period!", @"Appointment exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            OnRequestClose?.Invoke(this, new EventArgs());
        }


        /*private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment
            {
                Patient = patient,
                Room = room,
                Date = DateTime.Parse(Date.Text),
                StartTime = DateTime.Parse(TxtTime.Text),
                AppointmentType = AppointmentType.examination,
                Doctor = doctors[CbDoctor.SelectedIndex],
                IdAppointment = Guid.NewGuid().ToString("N"),
                ShouldSerialize = true
            };
            try
            {
                AppointmentRepository.Instance.Create(appointment);
                //appointmentController.Create(appointment);
                Apt.Add(appointment);
                //MessageBox.Show("You have succesfully created a new appointment");
            }
            catch (AppointmentConflictException)
            {
                MessageBox.Show("Appointment has already been scheduled in that period!");
            }
            //OnRequestClose(this, new EventArgs());
            Close();
        }*/


        public string PatientFullName { get; set; }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

    }
}


