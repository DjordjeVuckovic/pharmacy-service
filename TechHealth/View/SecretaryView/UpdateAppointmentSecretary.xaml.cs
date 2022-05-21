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
        private string id;
        public UpdateAppointmentSecretary(Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            id = appointment.IdAppointment;
            t = appointment.AppointmentType;
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
                if (!r.roomId.Equals("Warehouse"))
                {
                    rooms.Add(r);
                }
            }
            List<String> roomsForCombo = new List<String>();
            foreach (var r in rooms)
            {
                roomsForCombo.Add(r.roomId);
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
            roomCombo.SelectedItem = appointment.Room.roomId;

            datePick.Text = appointment.Date.ToString();
            timePickerStart.Text = appointment.StartTimeD.ToString("hh:mm tt");
            timePickerEnd.Text = appointment.FinishTimeD.ToString("hh:mm tt");
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
                FinishTimeD = DateTime.Parse(timePickerEnd.Text),
                StartTimeD = DateTime.Parse(timePickerStart.Text),
                IdAppointment = id,
                Patient = pa,
                Room = rooms[roomCombo.SelectedIndex],
                ShouldSerialize = true
            };
            appointmentController.Update(a);
            Close();
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}