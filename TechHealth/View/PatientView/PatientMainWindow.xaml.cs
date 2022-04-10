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
    /// Interaction logic for PatientMainWindow.xaml
    /// </summary>
    public partial class PatientMainWindow : Window
    {
        private static PatientMainWindow _instance;
        private ObservableCollection<Appointment> appointments;
        private static string patientId;


        public static PatientMainWindow GetInstance(string id)
        {

            if (_instance == null)
            {
                patientId = id;
                _instance = new PatientMainWindow();
            }
            return _instance;
        }
        public static PatientMainWindow GetInstance()
        {
            return _instance;
        }
        public PatientMainWindow()
        {
            //DispatcherTimer dispatcherTimer = new DispatcherTimer();
            InitializeComponent();
            _instance = this;
            appointments = new ObservableCollection<Appointment>();
            UpdateView();
            dataAppointment.ItemsSource = appointments;
        }

        public void UpdateView()
        {
            appointments.Clear();
            foreach (var t in AppointmentRepository.Instance.GetByPatientId(patientId))
            {
                appointments.Add(t);
            }
        }



        private void Appointment_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateAppointment(patientId).ShowDialog();
            UpdateView();

        }


        private void UpdateAppointment_OnClick(object sender, RoutedEventArgs e)
        {
            if (dataAppointment.SelectedIndex != -1)
            {
                UpdateAppointment updateAppointment = new UpdateAppointment((Appointment)dataAppointment.SelectedItem);
                updateAppointment.ShowDialog();
            }

            UpdateView();
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dataAppointment.SelectedIndex != -1)
            {
                Appointment appointment = (Appointment)dataAppointment.SelectedItem;
                AppointmentRepository.Instance.Delete(appointment.IdAppointment);
                MessageBox.Show("You have successfully deleted an appointment");
                UpdateView();
            }
        }
    }
}
