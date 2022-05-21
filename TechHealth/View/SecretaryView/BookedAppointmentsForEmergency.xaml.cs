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
            foreach (var a in from a in AppointmentRepository.Instance.GetAll().Values where a.Doctor.Jmbg.Equals(doctor.Jmbg) where a.Date.Equals(date) && a.AppointmentType.Equals(type) where DateTime.Compare(DateTime.Parse(a.StartTimeD.ToString("HH:mm")), DateTime.Now) >= 0 where DateTime.Compare(DateTime.Parse(a.StartTimeD.ToString("HH:mm")), DateTime.Now.AddMinutes(30)) <= 0 select a)
            {
                spec = doctorController.GetById(a.Doctor.Jmbg).FullSpecialization;
                name = patientController.GetByPatientId(a.Patient.Jmbg).FullName;
                AppointmentsDTO aDto = new AppointmentsDTO(a.IdAppointment, a.StartTimeD, a.FinishTimeD, spec, name, a.Room.roomId);
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
            Postpone(appointment);
            new EmergencyExamination().Show();
            Close();
        }
        private void Postpone(Appointment appointment)
        {
            for (int daysPostponed = 1; daysPostponed <= 5; daysPostponed++)
            {
                appointment.Date = appointment.Date.AddDays(1);
                appointment.StartTimeD = appointment.StartTimeD.AddDays(1);
                appointment.FinishTimeD = appointment.FinishTimeD.AddDays(1);
                if (CanPostone(appointment)) break;
            }
            appointmentController.Update(appointment);
        }

        private static bool CanPostone(Appointment appointment)
        {
            if (AppointmentRepository.Instance.CanPostpone(appointment))
            {
                return true;
            }

            return false;
        }
    }
}
