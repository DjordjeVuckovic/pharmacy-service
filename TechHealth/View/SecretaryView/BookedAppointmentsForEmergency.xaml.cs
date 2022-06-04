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
using TechHealth.Repository;
using TechHealth.Controller;
using System.Collections.ObjectModel;
using TechHealth.DTO;

namespace TechHealth.View.SecretaryView
{
    public partial class BookedAppointmentsForEmergency : Window
    {
        private AppointmentType type;
        private DateTime date;
        private AppointmentController appointmentController = new AppointmentController();
        private ObservableCollection<AppointmentsDTO> list = new ObservableCollection<AppointmentsDTO>();
        private string spec;
        private string name;
        private Doctor doctor;
        private DoctorController doctorController = new DoctorController();
        private PatientController patientController = new PatientController();
        public BookedAppointmentsForEmergency(Appointment appointment)
        {
            InitializeComponent();
            InitializeData(appointment);
            GenerateAppointments();
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void Button_Meetings(object sender, RoutedEventArgs e)
        {
            new MeetingsPickDate().Show();
            Close();
        }
        private void Button_Accounts(object sender, RoutedEventArgs e)
        {
            new AccountsView().Show();
            Close();
        }
        private void Button_Appointments(object sender, RoutedEventArgs e)
        {
            new AppointmentsPickDate().Show();
            Close();
        }
        private void Button_Equipment(object sender, RoutedEventArgs e)
        {
            new EquipmentRequestsView().Show();
            Close();
        }
        private void Button_EmergencyExamination(object sender, RoutedEventArgs e)
        {
            new EmergencyExamination().Show();
            Close();
        }
        private void InitializeData(Appointment appointment)
        {
            type = appointment.AppointmentType;
            date = appointment.Date;
            doctor = appointment.Doctor;
            pickedDate.Content = type.Equals(appointment.AppointmentType) ? "Booked Examinations " : "Booked Operations ";
            pickedDate.Content += date.ToString("dd.MM.yyyy.");
        }
        private void GenerateAppointments()
        {
            foreach (var a in from a in AppointmentRepository.Instance.GetAll().Values where a.Doctor.Jmbg.Equals(doctor.Jmbg) where a.Date.Equals(date) && a.AppointmentType.Equals(type) where DateTime.Compare(DateTime.Parse(a.StartTime.ToString("HH:mm")), DateTime.Now) >= 0 where DateTime.Compare(DateTime.Parse(a.StartTime.ToString("HH:mm")), DateTime.Now.AddMinutes(30)) <= 0 select a)
            {
                spec = doctorController.GetById(a.Doctor.Jmbg).FullSpecialization;
                name = patientController.GetByPatientId(a.Patient.Jmbg).FullName;
                AppointmentsDTO aDto = new AppointmentsDTO(a.IdAppointment, a.StartTime, a.FinishTime, spec, name, a.Room.RoomId);
                list.Add(aDto);
            }

            examinationList.ItemsSource = list;
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            Close();
        }
        private void Button_Click_Postpone(object sender, RoutedEventArgs e)
        {
            if (examinationList.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select an appointment.");
                return;
            }
            AppointmentsDTO a = (AppointmentsDTO)examinationList.SelectedItems[0];
            Appointment appointment = AppointmentRepository.Instance.GetById(a.idAppointment);
            appointmentController.Postpone(appointment);
            new EmergencyExamination().Show();
            Close();
        }
    }
}
