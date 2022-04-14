using System;
using System.Collections.Generic;
using System.Windows;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.CRUDAppointments
{
    /// <summary>
    /// Interaction logic for CreateSurgery.xaml
    /// </summary>
    public partial class CreateSurgery : Window
    {
        private Doctor doctor;
        private List<Patient> patients;
        private List<Room> rooms;
        public CreateSurgery(string doctorId)
        {
            InitializeComponent();
            doctor = DoctorRepository.Instance.GetDoctorbyId(doctorId);
            patients = PatientRepository.Instance.DictionaryValuesToList();
            rooms = RoomRepository.Instance.DictionaryValuesToList();

            DoctorTxt.Text = doctor.FullSpecialization;
            PatentCombo.ItemsSource = patients;
            RoomCombo.ItemsSource = rooms;
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure about that?", "Cancel appointment", MessageBoxButton.YesNo);
            if(dialogResult==MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (PatentCombo.SelectionBoxItem == null || Picker.SelectedDate == null ||
                PatentCombo.SelectionBoxItem == null || RoomCombo.SelectionBoxItem == null)
            {
                MessageBox.Show("Please fill all fields!");
            }
            else
            {
                Appointment appointment = new Appointment()
                {
                    AppointmentType = AppointmentType.operation,
                    Date = DateTime.Parse(Picker.Text),
                    Doctor = doctor,
                    Emergent = false,
                    FinishTime = FinishTxt.Text,
                    StartTime = StartTxt.Text,
                    IdAppointment = DateTime.Now.ToString("f"),
                    Patient = patients[PatentCombo.SelectedIndex],
                    Room = rooms[RoomCombo.SelectedIndex]
                };
                AppointmentRepository.Instance.Create(appointment);
                DoctorMainWindow.GetInstance().Appointments.Add(appointment);
                MessageBox.Show("You are successfully create new examination");
                Close();

            }
        }
    }
}
