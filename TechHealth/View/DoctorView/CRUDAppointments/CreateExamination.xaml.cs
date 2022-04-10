using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechHealth.Model;
using TechHealth.Repository;
using MessageBox = System.Windows.MessageBox;

namespace TechHealth.View.DoctorView.CRUDAppointments
{
    /// <summary>
    /// Interaction logic for CreateExamination.xaml
    /// </summary>
    public partial class CreateExamination : Window
    {
        private Doctor doctor;
        private List<Patient> patients;
        private List<Room> rooms;
        public CreateExamination(string doctorId)
        {
            InitializeComponent();
            doctor = DoctorRepository.Instance.GetDoctorbyId(doctorId);
            patients = PatientRepository.Instance.DictionaryValuesToList();
            rooms = RoomRepository.Instance.DictionaryValuesToList();

            DoctorTxt.Text = doctor.ToString();
            PatentCombo.ItemsSource = patients;
            RoomCombo.ItemsSource = rooms;

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
                    AppointmentType = AppointmentType.examination,
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
            
        }
    }
}
