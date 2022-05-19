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

namespace TechHealth.View.SecretaryView
{
    public partial class EmergencyExamination : Window
    {
        private DoctorController doctorController = new DoctorController();
        private AppointmentController appointmentController = new AppointmentController();
        public EmergencyExamination()
        {
            InitializeComponent();
            GeneratePatientsForComboBox();
            GenerateSpecializationsForComboBox();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Appointment appointment = GenerateAppointment();
            appointmentController.Create(appointment);
            Hide();
            new AppointmentsViewSecretary(appointment.Date, appointment.AppointmentType).Show();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            new SecretaryMainWindow().Show();
        }
        private void Button_Click_Add_Guest(object sender, RoutedEventArgs e)
        {
            Hide();
            new AddGuest(true).ShowDialog();
        }
        private Appointment GenerateAppointment()
        {
            Random random = new Random();
            Appointment appointment = new Appointment()
            {
                AppointmentType = AppointmentType.examination,
                Doctor = GetDoctor(),
                Date = DateTime.Parse(DateTime.Now.ToShortDateString()),
                StartTimeD = DateTime.Now.AddMinutes(5),
                FinishTimeD = DateTime.Now.AddMinutes(15),
                Emergent = true,
                IdAppointment = Guid.NewGuid().ToString("N"),
                Patient = GetPatientFromComboBox(),
                Room = RoomRepository.Instance.GetAllToList()[random.Next(1, RoomRepository.Instance.GetAllToList().Count)],
                ShouldSerialize = true
            };
            return appointment;
        }
        private void GeneratePatientsForComboBox()
        {
            List<String> patientsForCombo = new List<String>();
            foreach (var patient in PatientRepository.Instance.GetAllToList())
            {
                patientsForCombo.Add(patient.FullName);
            }
            patientCombo.ItemsSource = patientsForCombo;
        }
        private void GenerateSpecializationsForComboBox()
        {
            List<String> specializationsForCombo = new List<String>();
            foreach (var specialization in SpecializationRepository.Instance.GetAllToList())
            {
                specializationsForCombo.Add(specialization.NameSpecialization);
            }
            specializationCombo.ItemsSource = specializationsForCombo;
        }
        private Patient GetPatientFromComboBox()
        {
            foreach (var patient in PatientRepository.Instance.GetAllToList())
            {
                if (patientCombo.SelectedItem.Equals(patient.FullName))
                {
                    return patient;
                }
            }
            return null;
        }
        private int GetSpecializationIdFromComboBox()
        {
            foreach (var specialization in SpecializationRepository.Instance.GetAllToList())
            {
                if (specializationCombo.SelectedItem.Equals(specialization.NameSpecialization))
                {
                    return specialization.IdSpecialization;
                }
            }
            return -1;
        }
        private Doctor GetDoctor()
        {
            Random random = new Random();
            return doctorController.GetAllBySpecializationId(GetSpecializationIdFromComboBox())[random.Next(0, doctorController.GetAllBySpecializationId(GetSpecializationIdFromComboBox()).Count)];
        }
    }
}
