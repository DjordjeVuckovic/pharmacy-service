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

namespace TechHealth.View.PatientView
{
    /// <summary>
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        
        private Appointment appointment;
        private Patient patient;
        private List<Doctor> doctors;
        private List<Room> rooms;

        public UpdateAppointment(Appointment dataAppointmentSelectedItem)
        {
            InitializeComponent();
            appointment = dataAppointmentSelectedItem;
            patient = PatientRepository.Instance.GetPatientbyId(appointment.Patient.Jmbg);
            doctors = DoctorRepository.Instance.DictionaryValuesToList();
            rooms = RoomRepository.Instance.DictionaryValuesToList();

            DoctorCombo.ItemsSource = doctors;
            RoomCombo.ItemsSource = rooms;
            PatientTxt.Text = patient.ToString();
            SetUpValues();

        }

        private void SetUpValues()
        {
            Picker.Text = appointment.Date.ToString("f");
            StartTxt.Text = appointment.StartTime;
            FinishTxt.Text = appointment.FinishTime;
            int cnt = 0;
            foreach (var doctor in doctors)
            {
                if (doctor.Jmbg.Equals(appointment.Doctor.Jmbg))
                {
                    break;
                }

                cnt++;
            }

            DoctorCombo.SelectedIndex = cnt;
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
            if (DoctorCombo.SelectionBoxItem == null || Picker.SelectedDate == null ||
                DoctorCombo.SelectionBoxItem == null || RoomCombo.SelectionBoxItem == null)
            {
                MessageBox.Show("Please fill all fields!");
            }
            else
            {

                appointment.AppointmentType = AppointmentType.examination;
                appointment.Date = DateTime.Parse(Picker.Text);
                appointment.Patient = patient;
                appointment.FinishTime = FinishTxt.Text;
                appointment.StartTime = StartTxt.Text;
                appointment.Doctor = doctors[DoctorCombo.SelectedIndex];
                appointment.Room = rooms[RoomCombo.SelectedIndex];

                AppointmentRepository.Instance.Update(appointment);
                MessageBox.Show("You have successfully updated appointment");
                PatientMainWindow.GetInstance().UpdateView();
                Close();
            }
        }
    }
}
