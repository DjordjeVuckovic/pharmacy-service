﻿using System.Windows;

namespace TechHealth.DoctorView.CRUDAppointments
{
    /// <summary>
    /// Interaction logic for CreateExamination.xaml
    /// </summary>
    public partial class CreateExamination : Window
    {
        // private Doctor doctor;
        // private List<Patient> patients;
        // private List<Room> rooms;
        // private string doctorId;
        // private ObservableCollection<Appointment> Appointments { get; set; }
        public CreateExamination()
        {
            InitializeComponent();
            // DataContext = this;
            // doctor = DoctorRepository.Instance.GetDoctorbyId(doctorId);
            // patients = PatientRepository.Instance.GetAllToList();
            // rooms = RoomRepository.Instance.GetAllToList();
            // Appointments = observableCollection;
            //
            // DoctorTxt.Text = doctor.FullSpecialization;
            // PatentCombo.ItemsSource = patients;
            // RoomCombo.ItemsSource = rooms;
            // this.doctorId = doctorId;
        }

        /*private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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
                    AppointmentType = AppointmentType.examination,
                    Date = DateTime.Parse(Picker.Text),
                    Doctor = doctor,
                    Emergent = false,
                    FinishTime = FinishTxt.Text,
                    StartTime = StartTxt.Text,
                    IdAppointment = Guid.NewGuid().ToString("N"),
                    Patient = patients[PatentCombo.SelectedIndex],
                    Room = rooms[RoomCombo.SelectedIndex],
                    ShouldSerialize = true
                };
                Appointments.Add(appointment);
                RecordViewModel.GetInstance().Appointments.Add(appointment);
                AppointmentRepository.Instance.Create(appointment);
                MessageBox.Show("You are successfully create new examination");
                Close();

            }
        }
        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure about that?", "Cancel appointment", MessageBoxButton.YesNo);
            if(dialogResult==MessageBoxResult.Yes)
            {
                Close();
            }
            
        }*/
    }
}
