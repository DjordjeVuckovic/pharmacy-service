using System;
using System.Collections.Generic;
using System.Windows;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.CRUDAppointments
{
    /// <summary>
    /// Interaction logic for AppointmentsUpdate.xaml
    /// </summary>
    public partial class AppointmentsUpdate : Window
    {
        private Appointment appointment;
        private Doctor doctor;
        private List<Patient> patients;
        private List<Room> rooms;

        public AppointmentsUpdate(Appointment dataAppointmentSelectedItem)
        {
            InitializeComponent();
            appointment = dataAppointmentSelectedItem;
            doctor = DoctorRepository.Instance.GetDoctorbyId(appointment.Doctor.Jmbg);
            patients = PatientRepository.Instance.DictionaryValuesToList();
            rooms = RoomRepository.Instance.DictionaryValuesToList();

            PatentCombo.ItemsSource = patients;
            RoomCombo.ItemsSource = rooms;
            DoctorTxt.Text = doctor.FullSpecialization;
            SetUpValues();

        }

        private void SetUpValues()
        {
            Picker.Text = appointment.Date.ToString("f");
            StartTxt.Text = appointment.StartTime;
            FinishTxt.Text = appointment.FinishTime;
            int cnt = 0;
            foreach (var patient in patients)
            {
                if (patient.Jmbg.Equals(appointment.Patient.Jmbg))
                {
                    break;
                }

                cnt++;
            }

            PatentCombo.SelectedIndex = cnt;
            foreach (var r in rooms)
            {
                if (r.roomId.Equals(appointment.Room.roomId))
                {
                    break;
                }

                cnt++;
            }
            RoomCombo.SelectedIndex = cnt;

        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult =
                MessageBox.Show("Are you sure about that?", "Cancel appointment", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                Close();
            }

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Appointment app1 = appointment;
            if (PatentCombo.SelectionBoxItem == null || Picker.SelectedDate == null ||
                PatentCombo.SelectionBoxItem == null || RoomCombo.SelectionBoxItem == null)
            {
                MessageBox.Show("Please fill all fields!");
            }
            else
            {

                appointment.AppointmentType = AppointmentType.examination;
                appointment.Date = DateTime.Parse(Picker.Text);
                appointment.Doctor = doctor;
                appointment.FinishTime = FinishTxt.Text;
                appointment.StartTime = StartTxt.Text;
                appointment.Patient = patients[PatentCombo.SelectedIndex];
                appointment.Room = rooms[RoomCombo.SelectedIndex];
                UpdateList(app1);
                AppointmentRepository.Instance.Update(appointment);
                MessageBox.Show("You are successfully update appointment");
                Close();
            }
            
        }
        private void UpdateList(Appointment app1)
        {
            int index=AppointmentsWindow.GetInstance().Appointments.IndexOf(app1);
            AppointmentsWindow.GetInstance().Appointments.Remove(app1);
            AppointmentsWindow.GetInstance().Appointments.Insert(index, appointment);   
        } 
    }
}
