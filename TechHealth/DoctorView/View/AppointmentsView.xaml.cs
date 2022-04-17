using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TechHealth.DoctorView.CRUDAppointments;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.DoctorView.View
{
    public partial class AppointmentsView : UserControl
    {
        // public AppointmentsView()
        // {
        //     InitializeComponent();
        // }
        private static AppointmentsView _instance;
        private static string doctorId;
        private ObservableCollection<Appointment> _appointments;
        public static AppointmentsView GetInstance()
        {
            return _instance;
        }
        public AppointmentsView(string id)
        {
            InitializeComponent();
            _instance = this;
            doctorId = id;
            DataContext = this;
            _appointments = new ObservableCollection<Appointment>(AppointmentRepository.Instance.GetByDoctorId(doctorId));
        }

        public ObservableCollection<Appointment> Appointments
        {
            get
            {
                return _appointments;
            }
            set
            {
                _appointments = value;
                //OnPropertyChanged();
            }
        }
        private void Examination_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateExamination(doctorId).ShowDialog();
        }
       

        private void Surgery_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateSurgery(doctorId).ShowDialog();
        }

        private void UpdateExamination_OnClick(object sender, RoutedEventArgs e)
        {
            if (dataAppointment.SelectedIndex != -1)
            {
                AppointmentsUpdate updateAppointment = new AppointmentsUpdate((Appointment) dataAppointment.SelectedItem);
                updateAppointment.ShowDialog();
            }
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (dataAppointment.SelectedIndex != -1)
            {
                Appointment appointment = (Appointment) dataAppointment.SelectedItem;
                AppointmentRepository.Instance.Delete(appointment.IdAppointment);
                //Appointments.Remove(appointment);
                MessageBox.Show("You are successfully deleted an appointment");
            }
        }
        
    }
    }
