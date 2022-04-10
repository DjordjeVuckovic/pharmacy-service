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

namespace TechHealth.View.DoctorView.CRUDAppointments
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
            DoctorTxt.Text = doctor.ToString();
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
                
                AppointmentRepository.Instance.Update(appointment);
                MessageBox.Show("You are successfully update appointment");
                DoctorMainWindow.GetInstance().UpdateView();
                Close();
            }
        }
    }
}
