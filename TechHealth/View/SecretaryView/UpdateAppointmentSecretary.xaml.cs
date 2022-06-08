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
    public partial class UpdateAppointmentSecretary : Window
    {
        private List<Doctor> doctors = new List<Doctor>();
        private List<Patient> patients = PatientRepository.Instance.GetAllToList();
        private List<Room> rooms = new List<Room>();
        private AppointmentController appointmentController = new AppointmentController();
        private AppointmentType t;
        private DateTime d;
        private string id;
        public UpdateAppointmentSecretary(Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            id = appointment.IdAppointment;
            t = appointment.AppointmentType;
            d = appointment.Date;
            if (t.Equals(AppointmentType.examination))
            {
                addLabel.Content = "Edit Examination";
            }
            else
            {
                addLabel.Content = "Edit Operation";
            }
            List<String> doctorsForCombo = new List<String>();
            foreach (var d in DoctorRepository.Instance.GetAll().Values)
            {
                if (appointment.AppointmentType.Equals(AppointmentType.operation) && d.Specialization.IdSpecialization.Equals(0))
                {
                    continue;
                }
                else
                {
                    doctors.Add(d);
                    doctorsForCombo.Add(d.FullSpecialization);
                }
            }
            List<String> patientsForCombo = new List<String>();
            foreach (var p in patients)
            {
                patientsForCombo.Add(p.FullName);
            }
            foreach (var r in RoomRepository.Instance.GetAll().Values)
            {
                if (!r.RoomId.Equals("Warehouse"))
                {
                    rooms.Add(r);
                }
            }
            List<String> roomsForCombo = new List<String>();
            foreach (var r in rooms)
            {
                roomsForCombo.Add(r.RoomId);
            }
            doctorCombo.ItemsSource = doctorsForCombo;
            patientCombo.ItemsSource = patientsForCombo;
            roomCombo.ItemsSource = roomsForCombo;

            foreach (var p in PatientRepository.Instance.GetAll().Values)
            {
                if (p.Jmbg.Equals(appointment.Patient.Jmbg))
                {
                    patientCombo.SelectedItem = p.FullName;
                    break;
                }
            }

            foreach (var d in DoctorRepository.Instance.GetAll().Values)
            {
                if (d.Jmbg.Equals(appointment.Doctor.Jmbg))
                {
                    doctorCombo.SelectedItem = d.FullSpecialization;
                    break;
                }
            }
            roomCombo.SelectedItem = appointment.Room.RoomId;

            datePick.Text = appointment.Date.ToString();
            timePickerStart.Text = appointment.StartTime.ToString("hh:mm tt");
            timePickerEnd.Text = appointment.FinishTime.ToString("hh:mm tt");
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
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Doctor dr = new Doctor();
            foreach (var d in doctors)
            {
                if (doctorCombo.SelectedItem.Equals(d.FullSpecialization))
                {
                    dr = d;
                }
            }
            Patient pa = new Patient();
            foreach (var p in patients)
            {
                if (patientCombo.SelectedItem.Equals(p.FullName))
                {
                    pa = p;
                }
            }
            Appointment a = new Appointment()
            {
                AppointmentType = t,
                Date = DateTime.Parse(datePick.Text),
                Doctor = dr,
                Emergent = true,
                FinishTime = DateTime.Parse(timePickerEnd.Text),
                StartTime = DateTime.Parse(timePickerStart.Text),
                IdAppointment = id,
                Patient = pa,
                Room = rooms[roomCombo.SelectedIndex],
                ShouldSerialize = true
            };
            foreach (var app in AppointmentRepository.Instance.GetAll().Values)
            {
                if (a.Doctor.Jmbg.Equals(app.Doctor.Jmbg))
                {
                    if (a.Date.Equals(app.Date))
                    {
                        if (DateTime.Compare(DateTime.Parse(a.StartTime.ToString("HH:mm")), DateTime.Parse(app.StartTime.ToString("HH:mm"))) >= 0)
                        {
                            if (DateTime.Compare(DateTime.Parse(a.StartTime.ToString("HH:mm")), DateTime.Parse(app.FinishTime.ToString("HH:mm"))) <= 0)
                            {
                                if (a.IdAppointment != app.IdAppointment)
                                {
                                    MessageBox.Show("Doctor already has an appointment.");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            foreach (var app in AppointmentRepository.Instance.GetAll().Values)
            {
                if (a.Patient.Jmbg.Equals(app.Patient.Jmbg))
                {
                    if (a.Date.Equals(app.Date))
                    {
                        if (DateTime.Compare(DateTime.Parse(a.StartTime.ToString("HH:mm")), DateTime.Parse(app.StartTime.ToString("HH:mm"))) >= 0)
                        {
                            if (DateTime.Compare(DateTime.Parse(a.StartTime.ToString("HH:mm")), DateTime.Parse(app.FinishTime.ToString("HH:mm"))) <= 0)
                            {
                                if (a.IdAppointment != app.IdAppointment)
                                {
                                    MessageBox.Show("Patient already has an appointment.");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            appointmentController.Update(a);
            
            new AppointmentsViewSecretary(d, t).Show();
            Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            new AppointmentsViewSecretary(d, t).Show();
            Close();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            Close();
        }
    }
}