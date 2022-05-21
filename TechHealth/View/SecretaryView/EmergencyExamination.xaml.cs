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
        private DateTime closestStartTime;
        private DateTime closestFinishTime;
        private Doctor doctor = new Doctor();
        private bool isBusy;
        private bool appointmentBooked;
        public EmergencyExamination()
        {
            InitializeComponent();
            GeneratePatientsForComboBox();
            GenerateSpecializationsForComboBox();
            isBusy = false;
            appointmentBooked = false;
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
        }
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            GetClosestTime();
            Appointment appointment = GenerateAppointment();
            Hide();
            if (!appointmentBooked)
            {
                appointmentController.Create(appointment);
                new AppointmentsViewSecretary(appointment.Date, appointment.AppointmentType).Show();
            }
            else
            {
                new BookedAppointmentsForEmergency(appointment).Show();
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            this.Close();
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
                Doctor = doctor,
                Date = DateTime.Parse(DateTime.Now.ToShortDateString()),
                StartTimeD = closestStartTime,
                FinishTimeD = closestFinishTime,
                Emergent = true,
                IdAppointment = Guid.NewGuid().ToString("N"),
                Patient = GetPatientFromComboBox(),
                Room = RoomRepository.Instance.GetAllToList()[random.Next(1, RoomRepository.Instance.GetAllToList().Count)],
                ShouldSerialize = true
            };
            return appointment;
        }
        private void GetClosestTime()
        {
            for (int closestTimeCounter = 1; closestTimeCounter <= 30; closestTimeCounter++)
            {
                foreach (var d in doctorController.GetAllBySpecializationId(GetSpecializationIdFromComboBox()))
                {
                    doctor = d;
                    isBusy = false;
                    closestStartTime = DateTime.Now.AddMinutes(closestTimeCounter);
                    closestFinishTime = DateTime.Now.AddMinutes(closestTimeCounter + 10);
                    foreach (var appointment in AppointmentRepository.Instance.GetAll().Values)
                    {
                        if (appointment.Date.Equals(DateTime.Parse(DateTime.Now.ToShortDateString())))
                        {
                            if (appointment.Doctor.Jmbg.Equals(doctor.Jmbg))
                            {
                                if (DateTime.Compare(DateTime.Parse(closestStartTime.ToString("HH:mm")), DateTime.Parse(appointment.StartTimeD.ToString("HH:mm"))) >= 0)
                                {
                                    if (DateTime.Compare(DateTime.Parse(closestStartTime.ToString("HH:mm")), DateTime.Parse(appointment.FinishTimeD.ToString("HH:mm"))) <= 0)
                                    {
                                        isBusy = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (!isBusy) { return; }
                }
            }
            appointmentBooked = true;
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
    }
}
