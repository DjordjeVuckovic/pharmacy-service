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

namespace TechHealth.View.PatientView       //dodati IDappointment
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        //public event EventHandler OnRequestClose;
        private Patient patient;
        private Room room;
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private RoomController roomController = new RoomController();
        private List<Doctor> doctors;
        private List<Appointment> apList;
        private ObservableCollection<Appointment> Apt { get; set; }

        public AddAppointment(ObservableCollection<Appointment> listAppointment)
        {
            InitializeComponent();
            DataContext = this;
            Apt = listAppointment;
            patient = patientController.GetByPatientId("2456");
            room = roomController.GetById("S2");
            PatientFullName = patient.FullName;
            apList = AppointmentRepository.Instance.GetAllToList();
            

            //TxtPatient.Text = patient.FullName;
            doctors = DoctorRepository.Instance.GetAllToList();
            CbDoctor.ItemsSource = doctors;
        }


        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
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
        }

        public string PatientFullName { get; set; }

        //AppointmentRepository.Instance.Create(appointment); 
        //Close();

    }
    }



