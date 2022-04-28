using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TechHealth.Controller;
using TechHealth.DoctorView.View;
using TechHealth.DoctorView.ViewModel;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.CRUDAppointments
{
    /// <summary>
    /// Interaction logic for CreateSurgery.xaml
    /// </summary>
    public partial class CreateSurgery : Window
    {
        private readonly AppointmentController controller = new AppointmentController();
        private Doctor doctor;
        private List<Patient> patients;
        private List<Room> rooms;
        private ObservableCollection<Appointment> Appointments { get; set; }
        public CreateSurgery(string doctorId, ObservableCollection<Appointment> appointments)
        {
            InitializeComponent();
            DataContext = this;
            Appointments = appointments;
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
                //DateTime dateTime = DateTime.Parse(Picker.Text);
                Appointment appointment = new Appointment
                {
                    AppointmentType = AppointmentType.operation,
                    Date = DateTime.Parse(Picker.Text),
                    Doctor = doctor,
                    Emergent = false,
                    FinishTime = FinishTxt.Text,
                    StartTime = StartTxt.Text,
                    IdAppointment = Guid.NewGuid().ToString("N"),
                    Patient = patients[PatentCombo.SelectedIndex],
                    Room = rooms[RoomCombo.SelectedIndex],
                    FinishTimeD = DateTime.Parse(Timepicker1.Text),
                    ShouldSerialize = true
                };
                //AppointmentsWindow.GetInstance().Appointments.Add(appointment);
                //AppointmentsView.GetInstance().Appointments.Add(appointment);
                //RecordViewModel.GetInstance().Appointments.Add(appointment);
                //AppointmentIgnore ignore = new AppointmentIgnore(appointment);
                //AppointmentRepository.Instance.Create(appointment);
                Appointments.Add(appointment);
                controller.Create(appointment);
                MessageBox.Show("You are successfully create new examination");
                Close();

            }
        }

       
    }
}
