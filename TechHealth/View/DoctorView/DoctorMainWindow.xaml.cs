using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.DoctorView.CRUDAppointments;

namespace TechHealth.View.DoctorView
{
    public partial class DoctorMainWindow : Window
    {
        private static DoctorMainWindow _instance;
        private ObservableCollection<Appointment> appointments;
        private static string doctorId;
       

        public static DoctorMainWindow GetInstance(string id)
        {
            
                if (_instance == null)
                {
                     doctorId = id;
                    _instance = new DoctorMainWindow();
                }
                return _instance;
        }
        public static DoctorMainWindow GetInstance()
        {
            return _instance;
        }
        private DoctorMainWindow()
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
            foreach (var t in AppointmentRepository.Instance.GetByDoctorId(doctorId))
            {
                appointments.Add(t);
            }
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Examination_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateExamination(doctorId).ShowDialog();
            UpdateView();

        }
        // private void UpdateSurgery_OnClick(object sender, RoutedEventArgs e)
        // {
        //     //new UpdateExamination().ShowDialog();
        // }

        private void Surgery_OnClick(object sender, RoutedEventArgs e)
        {
            new CreateSurgery().ShowDialog();
        }

        private void UpdateExamination_OnClick(object sender, RoutedEventArgs e)
        {
            if (dataAppointment.SelectedIndex != -1)
            {
                AppointmentsUpdate updateAppointment = new AppointmentsUpdate((Appointment) dataAppointment.SelectedItem);
                updateAppointment.ShowDialog();
            }

            UpdateView();
        }
    }
}